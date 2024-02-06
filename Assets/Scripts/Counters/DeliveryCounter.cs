using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(PlayerController playerController) 
    {
        if (playerController.HasKitchenObject()) {
            if (playerController.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                // Only accepts Plates
                playerController.GetKitchenObject().DestroySelf();
            }
            
        }
    }
}
