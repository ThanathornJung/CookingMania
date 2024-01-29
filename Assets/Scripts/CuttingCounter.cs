using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cuttingObjectSO;

    public override void Interact(PlayerController playerController)
    {
        if (!HasKitchenObject()) {
            // There is no KitchenObject here
            if (playerController.HasKitchenObject()) {
                // Player is carrying something
                playerController.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                // Player not carrying anything
            }
        } else {
            // There is KitchenObject here
            if (playerController.HasKitchenObject()) {
                // Player is carrying something 
            } else {
                // Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(playerController);
            }
        }
    }

    public override void InteractAlternate(PlayerController playerController) {
        if (HasKitchenObject()) {
            // There is a KitchenObject here
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(cuttingObjectSO, this);
        }
    }
}
