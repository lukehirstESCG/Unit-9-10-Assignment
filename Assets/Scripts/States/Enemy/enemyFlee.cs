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

        if(ghostsm.EnemyDistance > 30)
        {
            enemyStateMachine.ChangeState(ghostsm.patrolState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        float distToPlayer = Vector3.Distance(ghostsm.enemy.transform.position, ghostsm.target.transform.position);

        if (distToPlayer > ghostsm.EnemyDistance)
        {
            Vector3 runDist = ghostsm.enemy.transform.position - ghostsm.target.transform.position;

            Vector3 newPos = ghostsm.enemy.transform.position + runDist;

            ghostsm.agent.SetDestination(newPos);
        }
    }
}
