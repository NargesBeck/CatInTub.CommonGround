using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator Animator;


    public void ToWalk()
    {
        Animator.SetTrigger("ToWalk");
    }

    public void Idle()
    {
        Animator.SetTrigger("ToIdle");
    }
}
