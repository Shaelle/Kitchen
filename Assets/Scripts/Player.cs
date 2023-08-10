using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 7;

    public event Action<bool> OnWalking;

    bool isWalking;

    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.I))
        {
            inputVector.y = +1;
        }

        if (Input.GetKey(KeyCode.K))
        {
            inputVector.y = -1;
        }

        if (Input.GetKey(KeyCode.J))
        {
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.L))
        {
            inputVector.x = +1;
        }
       
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);

    }

    public bool IsWalking()
    {
        return isWalking;
    }

}
