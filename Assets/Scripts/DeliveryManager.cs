using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;

    public event EventHandler<RecipeSuccessData> OnRecipeSuccess;

    public class RecipeSuccessData: EventArgs
    {
        public RecipeSO recipe;
    }

    public event EventHandler OnRecipeFailed;

    public static DeliveryManager Instance { get; private set; }

    [SerializeField] RecipeListSO recipeListSO;

    List<RecipeSO> waitingRecipies;

    float spawnRecipeTimer;
    float spawnRecipeTimerMax = 4;

    int waitingRecipesMax = 4;

    int succefulRecipesAmount;


    private void Awake()
    {

        Instance = this;


        waitingRecipies = new List<RecipeSO>();
    }

    private void Update()
    {
        if (KitchenGameManager.Instance.isGamePaused) return;

        spawnRecipeTimer -= Time.deltaTime;

        if (spawnRecipeTimer <= 0)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if (KitchenGameManager.Instance.IsGamePlaying() && waitingRecipies.Count < waitingRecipesMax)
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];

                waitingRecipies.Add(waitingRecipeSO);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }


    public void DeliverRecipe(PlateKitchenObject plate)
    {
        for (int i = 0; i < waitingRecipies.Count; i++)
        {
            RecipeSO recipe = waitingRecipies[i];

            if (recipe.kitchenObjectSOList.Count == plate.GetKitchenObjectSOList().Count)
            {
                // Has same number of ingredients
                bool plateContentMatchesRecipe = true;

                foreach (KitchenObjectSO recipeItem in recipe.kitchenObjectSOList)
                {
                    // Cycling through all ingredients in the recipe
                    bool ingredientFound = false;

                    foreach (KitchenObjectSO plateItem in plate.GetKitchenObjectSOList())
                    {
                        // Cycling through all ingredients in the plate
                        if (recipeItem == plateItem)
                        {
                            // Ingredient matches!
                            ingredientFound = true;
                            break;
                        }
                    }

                    if (!ingredientFound)
                    {
                        // This ingredient was not found on the plate
                        plateContentMatchesRecipe = false;
                    }
                }

                if (plateContentMatchesRecipe)
                {
                    //Player delivered the correct recipe!

                    succefulRecipesAmount++;

                    waitingRecipies.RemoveAt(i);

                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, new RecipeSuccessData { recipe = recipe });
                    return;
                }
            }
        }

        // No matches found!
        // Player did not delivered correct recipe
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
    }


    public List<RecipeSO> GetRecipeSOList()
    {
        return waitingRecipies;
    }


    public int GetSuccesfulRecipesAmount()
    {
        return succefulRecipesAmount;
    }

}
