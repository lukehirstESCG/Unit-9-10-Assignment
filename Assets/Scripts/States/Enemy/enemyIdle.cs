using UnityEngine;

public class enemyIdle : EnemyBaseState
{
    private EnemyMovementSM ghostsm;

    public enemyIdle(EnemyMovementSM enemyStateMachine) : base ("Idle", enemyStateMachine)
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

        if (Vector3.Distance(ghostsm.enemy.transform.position, ghostsm.target.position) <= 8)
        {
            enemyStateMachine.ChangeState(ghostsm.patrolState);
        }
    }
}
