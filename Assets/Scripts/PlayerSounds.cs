using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    Player player;

    float footstepTimer;
    float footstepTimerMax = 0.1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }


    private void Update()
    {
        footstepTimer -= Time.deltaTime;

        if (footstepTimer < 0)
        {
            footstepTimer = footstepTimerMax;

            if (player.IsWalking())
            {
                float volume = 1;
                SoundsManager.Instance.PlayFootstepSound(player.transform.position, volume);
            }
        }
    }
}
