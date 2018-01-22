using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : Interectable {

    //Nav Mesh
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    private bool walking;

    //Radius
    public float LookRadius;
    public float AttackRadius;

    //Attack
    private float nextAttack;
    public float AttackRate = 1f;

    //Target
    Transform targetPlayer;



	// Use this for initialization
	void Start ()
    {
        anim = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetPlayer = PlayerManager.instance.Player.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetBool("Walking", walking);

        if (!walking)
        {
            anim.SetBool("Idling", true);
        }
        else
        {
            anim.SetBool("Idling", false);
        }

        float distance = Vector3.Distance(transform.position, targetPlayer.position);
        if (distance <= LookRadius)
        {
            //move
            MoveAndAttack();
            //attack
        }
        else
        {
            walking = false;
            navMeshAgent.isStopped = true;
        }

	}

    void MoveAndAttack()
    {
        navMeshAgent.destination = targetPlayer.position;

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance > AttackRadius)
        {
            navMeshAgent.isStopped = false;
            walking = true;
        }
        else if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= AttackRadius)
        {
            //attack
            anim.SetBool("Attacking", false);
            transform.LookAt(targetPlayer);

            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + AttackRate;
                anim.SetBool("Attacking", true);
            }

            navMeshAgent.isStopped = true;
            walking = false;
        }

    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.yellow;
        Handles.DrawWireArc(transform.position + new Vector3(0, 0.2f, 0), transform.up, transform.right, 360, LookRadius);

        Handles.color = Color.red;
        Handles.DrawWireArc(transform.position + new Vector3(0, 0.2f, 0), transform.up, transform.right, 360, AttackRadius);
    }

    public override void Interact()
    {
        Debug.Log("Enemy got damaged");

        base.Interact();
    }


}
