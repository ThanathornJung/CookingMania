using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
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
        animator.SetBool(IS_WALKING, playerController.IsWalking());
    }
}
