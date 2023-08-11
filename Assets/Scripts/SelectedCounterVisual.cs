using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{

    [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject visualGameObject;


    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter) Show();
        else Hide();
    }


    void Show() => visualGameObject.SetActive(true);

    void Hide() => visualGameObject.SetActive(false);
}