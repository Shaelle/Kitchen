using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{

    [SerializeField] List<KitchenObjectSO> _kitchenObjectSOList;
    public List<KitchenObjectSO> kitchenObjectSOList => _kitchenObjectSOList;

    [SerializeField] string _recipeName;
    public string recipeName => _recipeName;

    [field: SerializeField, Min(0)] public float bonusTime { get; private set; }

}
