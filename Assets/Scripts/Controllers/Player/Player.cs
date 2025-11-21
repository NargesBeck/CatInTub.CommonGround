using UnityEngine;

[RequireComponent(typeof(PlayerCameraController))]
[RequireComponent(typeof(PlayerAnimationController))]
[RequireComponent(typeof(PlayerMovementController))]
public class Player : MonoBehaviour
{

    [SerializeField] private PlayerAnimationController PlayerAnimationController;
    [SerializeField] private PlayerMovementController PlayerMovementController;

    private void Start()
    {
        PlayerMovementController.OnMove = PlayerAnimationController.ToWalk;
        PlayerMovementController.OnStop = PlayerAnimationController.Idle;
    }
}
