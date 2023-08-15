using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    [SerializeField] KitchenObjectSO _input;
    public KitchenObjectSO input => _input;

    [SerializeField] KitchenObjectSO _output;
    public KitchenObjectSO output => _output;

    [SerializeField] float _fryingTimerMax;
    public float fryingTimerMax => _fryingTimerMax;

}
