using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 15f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    AudioMan am;

    float attackInterval = 2.5f;
    float chaseInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        am = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMan>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if (isProvoked) 
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void EngageTarget()
    {

        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Run");
        navMeshAgent.SetDestination(target.position);

        chaseInterval -= Time.deltaTime;

        if (chaseInterval > 0) return;

        chaseInterval = 5f;

        am.PlaySFX(am.zombieWalk);
    }

    void AttackTarget()
    {
        attackInterval -= Time.deltaTime;

        if (attackInterval > 0) return;

        attackInterval = 2.5f;

        GetComponent<Animator>().SetBool("Attack", true);
        am.PlaySFX(am.playerDamage);
        PlayerHealth ph = target.GetComponent<PlayerHealth>();
        ph.TakeDamage(25f);
    }


    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
