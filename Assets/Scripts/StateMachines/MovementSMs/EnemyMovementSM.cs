using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementSM : EnemyStateMachine
{
    public Transform target;
    public Transform enemy;
    public Transform[] points;
    public NavMeshAgent agent;
    [HideInInspector]
    public int dests;
    public bool attacking = false;

    [HideInInspector]
    public enemyIdle idleState;
    [HideInInspector]
    public enemyPatrol patrolState;
    [HideInInspector]
    public enemyChase chaseState;
    [HideInInspector]
    public enemyFlee fleeState;

    private void Awake()
    {
        idleState = new enemyIdle(this);
        patrolState = new enemyPatrol(this);
        chaseState = new enemyChase(this);
        fleeState = new enemyFlee(this);
    }

    protected override EnemyBaseState GetInitialState()
    {
        return idleState;
    }
}