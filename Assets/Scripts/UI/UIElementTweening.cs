using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIElementTweening : MonoBehaviour
{

    Vector3 initialPosition;

    const float initialOffset = 1000;

    float minTime = 0.9f;
    float maxTime = 1.6f;


    private void Awake()
    {
        initialPosition = transform.localPosition;
    }


    private void OnEnable()
    {
        PlayAnimation();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            PlayAnimation();
        }
    }


    void PlayAnimation()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOLocalMoveX(initialPosition.x - initialOffset, 0));
        sequence.Append(transform.DOLocalMoveX(initialPosition.x, Random.Range(minTime,maxTime)).SetEase(Ease.OutBack));

        sequence.Play();
    }
}
