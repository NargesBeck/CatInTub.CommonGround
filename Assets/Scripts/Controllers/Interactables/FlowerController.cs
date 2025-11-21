using UnityEngine;

[RequireComponent(typeof(FlowerView))]
public class FlowerController : MonoBehaviour, IInteractable
{
    private enum State { Pick, Water }
    private State CurrentState;

    private FlowerView view;
    private FlowerView View
    {
        get
        {
            if (view == null)
                view = GetComponent<FlowerView>();
            return view;
        }
    }

    private void Start()
    {

        View.Init();
    }

    public void Interact(string playerId)
    {
        Debug.Log("interacted with flower");
        // play vfx

        switch (CurrentState)
        {
            case State.Pick: SetStateFromPickToWater(); break;
            case State.Water: SetStateFromWaterToPick(); break;
        }

    }

    private void SetStateFromPickToWater()
    {
        View.ShowPickToWater();
        CurrentState = State.Water;
    }

    private void SetStateFromWaterToPick()
    {
        View.ShowWaterToPick();
        CurrentState = State.Pick;
    }
}
