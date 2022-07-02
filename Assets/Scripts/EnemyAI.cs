using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;



    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    { 
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (isProvoked)
        {
            EngageTarget();

        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void EngageTarget() 
    {
        if (navMeshAgent.stoppingDistance < distanceToTarget) 
        {
            chaseTarget();
        }

        if(navMeshAgent.stoppingDistance >= distanceToTarget)
        {
            attackTarget();
        }
    
    }

    private void chaseTarget() 
    {
        navMeshAgent.SetDestination(target.position);
    }
    private void attackTarget()
    {
        Debug.Log("Attacking");
    }

}
