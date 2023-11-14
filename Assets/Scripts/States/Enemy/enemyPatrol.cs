using UnityEngine;

public class enemyPatrol : EnemyBaseState
{
    private EnemyMovementSM ghostsm;

    public enemyPatrol(EnemyMovementSM enemyStateMachine) : base("Patrol", enemyStateMachine)
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

        if (Vector3.Distance(ghostsm.target.position, ghostsm.enemy.transform.position) > 8)
        {
            enemyStateMachine.ChangeState(ghostsm.idleState);
        }

        if (Vector3.Distance(ghostsm.target.position, ghostsm.enemy.transform.position) <= 3)
        {
            enemyStateMachine.ChangeState(ghostsm.chaseState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        if (!ghostsm.agent.pathPending && ghostsm.agent.remainingDistance < 0.5)
        {
            GoToNextPoint();
        }

        void GoToNextPoint()
        {
            if (ghostsm.points.Length == 0)
            {
                return;
            }
            ghostsm.agent.destination = ghostsm.points[ghostsm.dests].position;
            ghostsm.dests = (ghostsm.dests + 1) % ghostsm.points.Length;
        }
    }
}
