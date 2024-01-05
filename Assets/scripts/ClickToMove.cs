using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    Animator animator;

    [SerializeField] AudioSource walkingSound;
    [SerializeField] Transform movePositionTransform;
    private NavMeshAgent agent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            agent.destination = movePositionTransform.position;
        }
        
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    animator.SetBool("Walk", false);
                    walkingSound.Stop();
                }
            }
        }
        else
        {
            animator.SetBool("Walk", true);
            walkingSound.Play();
        }
        
    }
}
