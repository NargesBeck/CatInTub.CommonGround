using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera mainCamera;
    public Action OnMove;
    public Action OnStop;

    private Coroutine movementCoroutine;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
                OnMove?.Invoke();
                
                if (movementCoroutine != null)
                    StopCoroutine(movementCoroutine);
                movementCoroutine = StartCoroutine(WaitForDestination());
            }
        }
    }

    private IEnumerator WaitForDestination()
    {
        while (agent.pathPending)
            yield return null;

        while (agent.remainingDistance > agent.stoppingDistance)
            yield return null;
        OnStop?.Invoke();
    }
}