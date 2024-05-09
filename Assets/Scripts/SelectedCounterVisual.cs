using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;

    private void /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
     Start()
    {  
        if(PlayerController.LocalInstance != null) {
            PlayerController.LocalInstance.OnSelectedCounterChange += PlayerController_OnSelectedCounterChange;
        } else {
            PlayerController.OnAnyPlayerSpawned += PlayerController_OnAnyPlayerSpawned;
        }
    }

    private void PlayerController_OnAnyPlayerSpawned(object sender, System.EventArgs e) {
         if(PlayerController.LocalInstance != null) {
            PlayerController.LocalInstance.OnSelectedCounterChange -= PlayerController_OnSelectedCounterChange;
            PlayerController.LocalInstance.OnSelectedCounterChange += PlayerController_OnSelectedCounterChange;
        }
    }

    private void PlayerController_OnSelectedCounterChange(object sender, PlayerController.OnSelectedCounterChangedEventArgs e) {
        if (e.selectedCounter == baseCounter) {
            Show();
        } else {
            Hide();
        }
    }

    private void Show() {
        foreach(GameObject visualGameObject in visualGameObjectArray) {
            visualGameObject.SetActive(true);
        }
    }

    private void Hide() {
        foreach(GameObject visualGameObject in visualGameObjectArray) {
            visualGameObject.SetActive(false);
        }
    }

}
