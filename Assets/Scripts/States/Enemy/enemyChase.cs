using UnityEngine;

public class enemyChase : EnemyBaseState
{
    private EnemyMovementSM ghostsm;

    public enemyChase(EnemyMovementSM enemyStateMachine) : base ("Attack", enemyStateMachine)
    {
        ghostsm = enemyStateMachine;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // Is the player more than 20 metres away?
        if (Vector3.Distance(ghostsm.target.position, ghostsm.enemy.transform.position) > 20)
        {
            enemyStateMachine.ChangeState(ghostsm.patrolState);
        }

        // Has the target got their powerup active?
        if (ghostsm.power.Powered == true)
        {
            enemyStateMachine.ChangeState(ghostsm.fleeState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        ghostsm.agent.SetDestination(ghostsm.target.position);

        Vector3 direction = ghostsm.target.position - ghostsm.enemy.transform.position;

        ghostsm.enemy.transform.rotation = Quaternion.Slerp(ghostsm.enemy.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

        // Is the player less than or equal to 4 metres away?
        if (Vector3.Distance(ghostsm.target.position, ghostsm.enemy.transform.position) <= 4)
        {
            ghostsm.pHealth.TakeDamage(ghostsm.damage);
        }
    }
}
