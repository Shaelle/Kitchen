using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu()]
public class RecipeListSO : ScriptableObject
{

    [SerializeField] List<RecipeSO> _recipeSOList;
    public List<RecipeSO> recipeSOList => _recipeSOList;
}
