using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float turnSpeed = 5f;
    public Transform target;
    public float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    EnemyHealth health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.isDead) 
        { enabled = false; 
          navMeshAgent.enabled = false;
        }
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
        faceTarget();

        if (navMeshAgent.stoppingDistance < distanceToTarget) 
        {
            chaseTarget();
        }

        if(navMeshAgent.stoppingDistance >= distanceToTarget)
        {
            attackTarget();
        }
    
    }

    public void AmIGetShoot() 
    {

        isProvoked = true;
    
    }

    private void chaseTarget() 
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move 0");
        navMeshAgent.SetDestination(target.position);
    }
    private void attackTarget()
    {
        GetComponent<Animator>().SetBool("Attack",true);
       
    }

    private void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

    }

}
