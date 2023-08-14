using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject
{

    [SerializeField] Transform _prefab;
    public Transform prefab => _prefab;

    [SerializeField] Sprite _sprite;
    public Sprite sprite => _sprite;

    [SerializeField] string _objectName;
    public string objectName => _objectName;

}
