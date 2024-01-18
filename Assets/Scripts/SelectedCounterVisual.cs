using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;

    private void /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
     Start()
    {  
        PlayerController.Instance.OnSelectedCounterChange += PlayerController_OnSelectedCounterChange;
    }

    private void PlayerController_OnSelectedCounterChange(object sender, PlayerController.OnSelectedCounterChangedEventArgs e) {
        if (e.selectedCounter == clearCounter) {
            Show();
        } else {
            Hide();
        }
    }

    private void Show() {
        visualGameObject.SetActive(true);
    }

    private void Hide() {
        visualGameObject.SetActive(false);
    }

}
