using UnityEngine;

[RequireComponent(typeof(PlayerCameraController))]
[RequireComponent(typeof(PlayerAnimationController))]
[RequireComponent(typeof(PlayerMovementController))]
[RequireComponent(typeof(PlayerBehaviourController))]
[RequireComponent(typeof(PlayerInputController))]

public class Player : MonoBehaviour
{
    #region Controllers
    private PlayerCameraController playerCameraController;
    private PlayerCameraController PlayerCameraController
    {
        get
        {
            if (playerCameraController == null) playerCameraController = GetComponent<PlayerCameraController>();
            return playerCameraController;
        }
    }

    private PlayerAnimationController playerAnimationController;
    private PlayerAnimationController PlayerAnimationController
    {
        get
        {
            if (playerAnimationController == null) playerAnimationController = GetComponent<PlayerAnimationController>();
            return playerAnimationController;
        }
    }

    private PlayerMovementController playerMovementController;
    private PlayerMovementController PlayerMovementController
    {
        get
        {
            if (playerMovementController == null)
                playerMovementController = GetComponent<PlayerMovementController>();
            return playerMovementController;
        }
    }

    private PlayerBehaviourController playerBehaviourController;
    private PlayerBehaviourController PlayerBehaviourController
    {
        get
        {
            if (playerBehaviourController == null)
                playerBehaviourController = GetComponent<PlayerBehaviourController>();
            return playerBehaviourController;
        }
    }

    private PlayerInputController playerInputController;
    private PlayerInputController PlayerInputController
    {
        get
        {
            if (playerInputController == null)
                playerInputController = GetComponent<PlayerInputController>();
            return playerInputController;
        }
    }
    #endregion

    private void Start()
    {
        PlayerMovementController.OnMove = PlayerAnimationController.ToWalk;
        PlayerMovementController.OnStop = PlayerAnimationController.Idle;
        PlayerMovementController.OnStop += PlayerBehaviourController.OnReachDestination;
        GroundMarker.Instance.OnMouseClick = PlayerMovementController.SetDestination;

    }
}
