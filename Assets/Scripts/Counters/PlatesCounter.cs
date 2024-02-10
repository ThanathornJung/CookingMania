using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter    
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;

    private float spawnPlateTimer;
    private float spawnPlaterTimerMax = 4f; 
    private int platesSpawnedAmount;
    private int platesSpawnedAmountMax = 4;

    private void Update() {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlaterTimerMax) {
            spawnPlateTimer = 0f;

            if (GameManager.Instance.IsGamePlaying() && platesSpawnedAmount < platesSpawnedAmountMax) {
                platesSpawnedAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(PlayerController playerController)
    {
        if (!playerController.HasKitchenObject()) {
            // Player is empty handed
            if (platesSpawnedAmount > 0) {
                // There's at least one plate here
                platesSpawnedAmount--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, playerController);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
