using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyState
    {
        patrolling,
        chasing
    }

    public EnemyState enemyState;

    public NavMeshAgent agent;
    public GameObject player;

    private float shootingDistance = 12f;

    private float updateDeadline;
    private float updateDelay = 0.2f;

    public bool inRange = false;

    private Vector3 HomePos;

    // Start is called before the first frame update
    void Start()
    {
        HomePos = transform.position;

        IslandSafeSpace.OnPlayerEntered += StopChasing;
        IslandSafeSpace.OnPlayerExited += StartChasing;

        agent.SetDestination(HomePos);
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.patrolling:
                agent.SetDestination(HomePos);
                break;
            case EnemyState.chasing:
                // Check if player is in shooting range
                inRange = Vector3.Distance(transform.position, player.transform.position) <= shootingDistance;

                if (inRange)
                    targetPlayer();
                else
                    updatePath();
                break;
        }
    }

    private void targetPlayer()
    {
        Vector3 targetPos = player.transform.position - transform.position;
        targetPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(targetPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1f);
    }

    // Updates the path to player's location
    private void updatePath()
    {
        if(Time.time >= updateDeadline)
        {
            updateDeadline = Time.time + updateDelay;
            agent.SetDestination(player.transform.position);
        }
    }

    public void StartChasing()
    {
        enemyState = EnemyState.chasing;
    }

    public void StopChasing()
    {
        enemyState = EnemyState.patrolling;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingDistance);
    }
}
