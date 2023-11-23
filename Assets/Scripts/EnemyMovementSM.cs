using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementSM : EnemyStateMachine
{
    public Transform target;
    public PlayerHealth pHealth;
    public PowerUp power;
    public float damage;
    public float EnemyDistance = 30;
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

    // Damage Cooldown for enemies.
    public IEnumerator DamageCooldown()
    {
        pHealth.TakeDamage(damage);
        attacking = true;
        yield return new WaitForSeconds(5);
        attacking = true;
    }
}
