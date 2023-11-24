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

        if (ghostsm.power.Powered == false)
        {
            enemyStateMachine.ChangeState(ghostsm.patrolState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        float distance = Vector3.Distance(ghostsm.enemy.transform.position, ghostsm.target.position);

        if (distance < ghostsm.EnemyDistance)
        {
            Vector3 distToPlayer = ghostsm.enemy.transform.position - ghostsm.target.transform.position;

            Vector3 newPos = ghostsm.enemy.transform.position + distToPlayer;

            ghostsm.agent.SetDestination(newPos);
        }
    }
}
