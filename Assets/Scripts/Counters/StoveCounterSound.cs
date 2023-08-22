using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{

    [SerializeField] StoveCounter stoveCounter;

    AudioSource audioSource;

    float warningSoundTimer;
    bool playWarningSound;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
    }


    private void OnDestroy()
    {
        stoveCounter.OnStateChanged -= StoveCounter_OnStateChanged;
        stoveCounter.OnProgressChanged -= StoveCounter_OnProgressChanged;
    }

    private void Update()
    {
        if (playWarningSound)
        {
            warningSoundTimer -= Time.deltaTime;

            if (warningSoundTimer < 0)
            {
                float warningSoundTimerMax = 0.2f;
                warningSoundTimer = warningSoundTimerMax;

                SoundsManager.Instance.PlayWarningSound(stoveCounter.transform.position);
            }
        }       
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burnShowProgressAmount = 0.5f;
        playWarningSound = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;

    }


    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool playSound = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;

        if (playSound) audioSource.Play();
        else audioSource.Pause();
    }
}
