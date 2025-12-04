using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerMovementController : MonoBehaviour
{
    private NavMeshAgent agent;
    private NavMeshAgent Agent
    {
        get
        {
            if (agent == null)
                agent = GetComponent<NavMeshAgent>();
            return agent;
        }
    }

    public Action OnMove;
    public Action OnStop;

    private Coroutine movementCoroutine;

    public void Move(Vector3 point)
    {
        // called by input controller
        // will notify necessary controllers via calling on move and on stop actions
        Agent.SetDestination(point);
        OnMove?.Invoke();

        if (movementCoroutine != null)
            StopCoroutine(movementCoroutine);
        movementCoroutine = StartCoroutine(WaitForDestination());
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