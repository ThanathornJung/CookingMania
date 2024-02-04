using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(PlayerController playerController) {
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
                if (playerController.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    // Player is holding a Plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {
                        GetKitchenObject().DestroySelf();
                    }
                } else {
                    // Player is not carrying Plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) {
                        // Counter is holding a Plate
                        if (plateKitchenObject.TryAddIngredient(playerController.GetKitchenObject().GetKitchenObjectSO())) {
                            playerController.GetKitchenObject().DestroySelf();
                        }
                    }
                } 
            } else {
                // Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(playerController);
            }
        }
    }
}
