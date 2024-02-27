using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickPoint();
    }
    void Update()
    {
        Noticed();
        ChaseUpdate();
        UpdatePickPoint();
    }
    private void PickPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void UpdatePickPoint()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickPoint();
            }
        }
    }
    private void Noticed()
    {
        var direction = player.transform.position - transform.position;
                _isPlayerNoticed = false;
                if (Vector3.Angle(transform.forward, direction) < viewAngle)
                {
                    RaycastHit hit;
                            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
                            {
                                if (hit.collider.gameObject == player.gameObject)
                                {
                                    _isPlayerNoticed = true;
                                }
                            }
                }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
        if (_navMeshAgent.remainingDistance == 0)
        {
            _navMeshAgent.isStopped = true;
        }
    }
}
