using UnityEngine;

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
