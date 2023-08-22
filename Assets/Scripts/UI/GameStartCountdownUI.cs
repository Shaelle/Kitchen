using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartCountdownUI : MonoBehaviour
{

    const string NUMBER_POPUP = "NumberPopup";

    [SerializeField] TextMeshProUGUI countDownText;

    Animator animator;

    int previosCountdownNumber;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        KitchenGameManager.Instance.OnGamePaused += OnPause;
        KitchenGameManager.Instance.OnGameUnpaused += OnUnpause;

        Hide();
    }


    private void OnDestroy()
    {
        KitchenGameManager.Instance.OnStateChanged -= KitchenGameManager_OnStateChanged;

        KitchenGameManager.Instance.OnGamePaused -= OnPause;
        KitchenGameManager.Instance.OnGameUnpaused -= OnUnpause;
    }


    private void OnUnpause(object sender, System.EventArgs e) => animator.speed = 1;

    private void OnPause(object sender, System.EventArgs e) => animator.speed = 0;


    private void Update()
    {
        int countdownNumber = Mathf.CeilToInt(KitchenGameManager.Instance.GetCountdownToStartTimer());
        countDownText.text = countdownNumber.ToString();

        if (previosCountdownNumber != countdownNumber)
        {
            previosCountdownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            SoundsManager.Instance.PlayCountdownSound();
        }
    }


    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.isCountdownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    void Show()
    {
        gameObject.SetActive(true);
    }


    void Hide()
    {
        gameObject.SetActive(false);
    }
}
