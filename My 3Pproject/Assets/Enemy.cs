using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public bool running;
    Transform target;
    NavMeshAgent agent;
    GameObject damageDealer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //transform.position+=(target.position-transform.position)*Time.deltaTime*0.3f;
        if (!target)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }

    public void SawPlayer(GameObject player)
    {
        target = player.transform;
        running = target != null;
        animator.SetBool("Running", running);
    }
    public void LostPlayer(GameObject player)
    {
        target = player.transform == target ? null : target;
        running = target != null;
        animator.SetBool("Running", running);
    }
    public void AttackPlayer()
    {
        animator.SetTrigger("Attacking");
    }
    public void ActivateDamageDealer()
    {
        damageDealer.SetActive(true);

    }
    public void DeactivateDamageDealer()
    {
        damageDealer.SetActive(false);

    }
}