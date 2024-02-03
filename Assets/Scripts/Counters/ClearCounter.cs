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
            } else {
                // Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(playerController);
            }
        }
    }
}
