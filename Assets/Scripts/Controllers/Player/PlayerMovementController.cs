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
    private Transform _transform;
    private Transform Transform
    {
        get
        {
            if (_transform == null)
                _transform = transform;
            return _transform;
        }
    }

    public Action OnMove;
    public Action OnStop;

    private float moveDelayAfterRotation = 0.1f;
    private float rotationSpeed = 900;
    private bool rotating;
    private Vector3 targetDirection;
    private Vector3 pendingDestination;
    private Coroutine movementCoroutine;

    private void Update()
    {
        if (rotating)
        {
            RotateTowardsTarget();
        }
        else if (Agent.hasPath && Agent.remainingDistance > Agent.stoppingDistance)
        {
            Agent.isStopped = false;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        Agent.isStopped = true;
        pendingDestination = destination;

        if (TryRotate(destination) == false)
        {
            // If no rotation needed, move immediately
            StartMoving();
        }
    }

    private bool TryRotate(Vector3 destination)
    {
        // Calculate direction
        targetDirection = (destination - Transform.position).normalized;
        targetDirection.y = 0;

        if (targetDirection != Vector3.zero)
        {
            // Check if we need to rotate (if not already facing roughly that direction)
            float angle = Vector3.Angle(Transform.forward, targetDirection);
            if (angle > 5f) // Only rotate if angle is significant
            {
                rotating = true;
                return true;
            }
        }
        return false;
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Transform.rotation = Quaternion.RotateTowards(
            Transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        // Check if rotation is complete
        if (Quaternion.Angle(Transform.rotation, targetRotation) < 1f)
        {
            rotating = false;
            StartMoving();
        }
    }

    private void StartMoving()      
    {
        // called by input controller
        // will notify necessary controllers via calling on move and on stop actions
        Agent.SetDestination(pendingDestination);
        Agent.isStopped = false;
        OnMove?.Invoke();
        if (movementCoroutine != null)
            StopCoroutine(movementCoroutine);
        movementCoroutine = StartCoroutine(WaitForDestination());
    }

    private IEnumerator WaitForDestination()
    {
        while (Agent.pathPending)
            yield return null;

        while (Agent.remainingDistance > Agent.stoppingDistance)
            yield return null;
        OnStop?.Invoke();
    }
}