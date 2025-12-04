using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private Camera mainCamera;
    private Camera MainCamera
    {
        get
        {
            if (mainCamera == null)
                mainCamera = Camera.main;
            return mainCamera;
        }
    }

    public Action<Vector3> OnInputToMove;
    public Action<IInteractable> OnInputToInteract;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // call movement - hit.point
                OnInputToMove?.Invoke(hit.point);

                // if interactable then call behaviour to queue
                // have movement notify behaviour class
                IInteractable selected = hit.transform.GetComponent<IInteractable>();
                if (selected != null)
                {
                    OnInputToInteract?.Invoke(selected);
                }
            }
        }
    }
}
