using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{

    [SerializeField] Transform counterTopPoint;

    KitchenObject kitchenObject;


    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter interact");
    }


    public virtual void InteractAlternate(Player player)
    {

    }

    public Transform GetKitchenObjectFollowTransform() => counterTopPoint;

    public void SetKitchenObject(KitchenObject kitchenObject) => this.kitchenObject = kitchenObject;

    public KitchenObject GetKitchenObject() => kitchenObject;

    public void ClearKitchenObject() => kitchenObject = null;

    public bool HasKitchenObject() => kitchenObject != null;

}
