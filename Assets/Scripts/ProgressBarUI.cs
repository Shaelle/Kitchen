using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] GameObject hasProgressGameObject;
    [SerializeField] Image barImage;

    IHasProgress hasProgress;

    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();

        if (hasProgress == null)
            Debug.LogError("Game object " + hasProgressGameObject + " does not have component that implements IHasProgress!");

        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;

        barImage.fillAmount = 0;
        Hide();
    }

    private void OnDestroy()
    {
        hasProgress.OnProgressChanged -= HasProgress_OnProgressChanged;
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 0 || e.progressNormalized == 1) Hide();
        else Show();
    }


    void Show() => gameObject.SetActive(true);
    void Hide() => gameObject.SetActive(false);
}
