using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] KitchenObjectSO plateKitchenObjectSO;

    float spawnPlateTimer;
    float spawnTimerMax = 4;

    int platesSpawnedAmount;
    int platesSpawnedAmountMax = 4;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnTimerMax)
        {
            spawnPlateTimer = 0;

            if (platesSpawnedAmount < platesSpawnedAmountMax)
            {
                platesSpawnedAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }


    }


    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // Player is empty handed
            if (platesSpawnedAmount > 0)
            {
                // There is at least one plate here
                platesSpawnedAmount--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }

    }

}
