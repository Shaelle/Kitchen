using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{

    [SerializeField] Image timerImage;

    [SerializeField] Color colorNormal;
    [SerializeField] Color colorWarning;
    [SerializeField] Color colorCritical;

    [SerializeField, Range(0,1)] float warningThreshold = 0.6f;
    [SerializeField, Range(0, 1)] float criticalThreshold = 0.9f;


    private void Start() => timerImage.color = colorNormal;


    private void Update()
    {

        if (KitchenGameManager.Instance.IsGamePlaying())
        {
            float timer = KitchenGameManager.Instance.GetGamePlayingTimerNormalized();

            timerImage.fillAmount = timer;

            if (timer < warningThreshold) timerImage.color = colorNormal;
            else if (timer < criticalThreshold) timerImage.color = colorWarning;
            else timerImage.color = colorCritical;
        }
    }

}
