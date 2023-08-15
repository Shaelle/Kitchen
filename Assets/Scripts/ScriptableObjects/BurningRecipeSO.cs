using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject
{
    [SerializeField] KitchenObjectSO _input;
    public KitchenObjectSO input => _input;

    [SerializeField] KitchenObjectSO _output;
    public KitchenObjectSO output => _output;

    [SerializeField] float _burningTimerMax;
    public float burningTimerMax => _burningTimerMax;

}
