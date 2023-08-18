using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipsSO : ScriptableObject
{

    [SerializeField] AudioClip[] _chop;
    public AudioClip[] chop => _chop;

    [SerializeField] AudioClip[] _deliveryFail;
    public AudioClip[] deliveryFail => _deliveryFail;

    [SerializeField] AudioClip[] _deliverySuccess;
    public AudioClip[] deliverySuccess => _deliverySuccess;

    [SerializeField] AudioClip[] _footstep;
    public AudioClip[] footstep => _footstep;

    [SerializeField] AudioClip[] _objectDrop;
    public AudioClip[] objectDrop => _objectDrop;

    [SerializeField] AudioClip[] _objectPickup;
    public AudioClip[] objectPickup => _objectPickup;

    [SerializeField] AudioClip _stoveSizzle;
    public AudioClip stoveSizzle => _stoveSizzle;

    [SerializeField] AudioClip[] _trash;
    public AudioClip[] trash => _trash;

    [SerializeField] AudioClip[] _warning;
    public AudioClip[] warning => _warning;



}
