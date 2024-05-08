using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerAnimator : NetworkBehaviour 
{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private PlayerController playerController;

    private Animator animator;

    private void /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    Awake()
    {
        animator = GetComponent<Animator>(); 
    }

    private void /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
     Update()
    {
        if(!IsOwner) {
            return;
        }
        
        animator.SetBool(IS_WALKING, playerController.IsWalking());
    }
}
