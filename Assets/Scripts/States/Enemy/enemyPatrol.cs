using UnityEngine;
using UnityEngine.AI;

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

        // Is the player more than 128 metres away?
        if (Vector3.Distance(ghostsm.target.position, ghostsm.enemy.transform.position) > 128)
        {
            enemyStateMachine.ChangeState(ghostsm.idleState);
        }

        // Is the player less than or equal to 20 metres away?
        if (Vector3.Distance(ghostsm.target.position, ghostsm.enemy.transform.position) <= 20)
        {
            enemyStateMachine.ChangeState(ghostsm.chaseState);
        }

        // Has the player got a power-up active?
        if (ghostsm.power.Powered == true)
        {
            enemyStateMachine.ChangeState(ghostsm.fleeState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        // Is there a path NOT pending?
        if (!ghostsm.agent.pathPending && ghostsm.agent.remainingDistance < 0.5)
        {
            GoToNextPoint();
        }

        void GoToNextPoint()
        {
            // End of path.
            if (ghostsm.points.Length == 0)
            {
                return;
            }
            ghostsm.agent.destination = ghostsm.points[ghostsm.dests].position;
            ghostsm.dests = (ghostsm.dests + 1) % ghostsm.points.Length;
        }
    }
}
