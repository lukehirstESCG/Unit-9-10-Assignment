using UnityEngine;

public class enemyFlee : EnemyBaseState
{
    private EnemyMovementSM ghostsm;

    public enemyFlee(EnemyMovementSM enemyStateMachine) : base("Flee", enemyStateMachine)
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

        if(ghostsm.power.Powered == false)
        {
            enemyStateMachine.ChangeState(ghostsm.patrolState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        Vector3 direction = ghostsm.enemy.transform.position - ghostsm.target.transform.position;
    }
}
