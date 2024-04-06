using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;

    private float shootingDistance = 12f;

    private float updateDeadline;
    private float updateDelay = 0.2f;

    public bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is in shooting range
        inRange = Vector3.Distance(transform.position, player.transform.position) <= shootingDistance;

        if (inRange)        
            targetPlayer();               
        else
            updatePath();
    }

    private void targetPlayer()
    {
        Vector3 targetPos = player.transform.position - transform.position;
        targetPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(targetPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1f);
    }

    private void updatePath()
    {
        if(Time.time >= updateDeadline)
        {
            updateDeadline = Time.time + updateDelay;
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingDistance);
    }
}
