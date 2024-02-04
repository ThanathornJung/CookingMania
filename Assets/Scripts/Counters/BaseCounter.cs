using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private Transform counterTopPoint;

    protected KitchenObject kitchenObject;

    public virtual void Interact(PlayerController playerController) {
        Debug.LogError("BaseCounter.Interact();");
    }

    public virtual void InteractAlternate(PlayerController playerController) {
        //Debug.LogError("BaseCounter.InteractAlternate();");
    }

     public Transform GetKitchenObjectFollowTransform() {
        return counterTopPoint;
    }
    
    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }
}
