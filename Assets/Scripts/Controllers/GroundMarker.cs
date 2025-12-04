using System;
using UnityEngine;
using UnityEngine.AI;

public class GroundMarker : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform marker;

    private static GroundMarker instance;
    public static GroundMarker Instance
    {
        get
        {
            if (instance == null)
                instance = FindAnyObjectByType<GroundMarker>();
            return instance;
        }
    }

    public Action<Vector3> OnMouseClick;

    private void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            NavMeshHit navHit;
            if (NavMesh.SamplePosition(hit.point, out navHit, 100f, NavMesh.AllAreas))
            {
                // Move marker to valid NavMesh position
                SetPosition(hit.point);
            }
            else
            {
                Debug.Log("No NavMesh found near hit point!");
            }
        }
        else
        {
            Debug.Log("No raycast hit!");
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClick?.Invoke(marker.position);
        }
    }

    private void SetPosition(Vector3 position)
    {
        marker.position = new Vector3(position.x, 0.1f, position.z);
    }
}