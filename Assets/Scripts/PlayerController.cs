using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask; 

    private bool isWalking;
    private Vector3 lastInteractDir;

    private void /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
     Start() {
        gameInput.OnInteractAction += GameInput_OnInterAction;
    }

    private void GameInput_OnInterAction(object sender, System.EventArgs e) {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero) {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, counterLayerMask)) {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)) {
                // Has ClearCounter
                clearCounter.Interact();
            }
        }
    }

    private void Update() {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking() {
        return isWalking;
    }

    private void HandleInteractions() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero) {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, counterLayerMask)) {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)) {
                // Has ClearCounter
            }
        }
    }

    private void HandleMovement() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove) {
            // Cannot move towards moveDir

            // Attemp only X movement
            Vector3 moveDirX = new Vector3(moveDir.x,0,0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove) {
                // Can move only on the x
                moveDir = moveDirX;
            } else {
                // Cannot move only on the x

                // Attemp only z movement
                Vector3 moveDirZ = new Vector3(0,0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove) {
                    // Can move only on the Z
                    moveDir = moveDirZ;
                } else {
                    // Cannot move in any direction
                }
            }
        }

        if (canMove) {
            transform.position += moveDir * moveDistance;
        }
        
        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }
}
