using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeSO : ScriptableObject
{
    [SerializeField] KitchenObjectSO _input;
    public KitchenObjectSO input => _input;

    [SerializeField] KitchenObjectSO _output;
    public KitchenObjectSO output => _output;

    [SerializeField] int _cuttingProgressMax;
    public int cuttingProgressMax => _cuttingProgressMax;

}
