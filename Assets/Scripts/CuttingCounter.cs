using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingObjectSOArray;

    public override void Interact(PlayerController playerController)
    {
        if (!HasKitchenObject()) {
            // There is no KitchenObject here
            if (playerController.HasKitchenObject()) {
                // Player is carrying something
                if (HasRecipeWithInput(playerController.GetKitchenObject().GetKitchenObjectSO())) {
                    // Player carrying something that can be Cut
                    playerController.GetKitchenObject().SetKitchenObjectParent(this);
                }     
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
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())) {
            // There is a KitchenObject here AND it can be CUT
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO) {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingObjectSOArray) {
            if (cuttingRecipeSO.input == inputKitchenObjectSO) {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO) {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingObjectSOArray) {
            if (cuttingRecipeSO.input == inputKitchenObjectSO) {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }
}
