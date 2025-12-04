using UnityEngine;

public class PlayerBehaviourController : MonoBehaviour
{
    private IInteractable QueuedActivity;

    public void InitInteract(IInteractable interactable)
    {
        interactable.Interact();
        QueuedActivity = interactable;
    }

    public void OnReachDestination()
    {
        if (QueuedActivity != null)
        {
            QueuedActivity.ChangeState();
        }
    }
}