using UnityEngine;
using UnityEngine.AI;

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

        if (Vector3.Distance(ghostsm.target.position, ghostsm.enemy.transform.position) > 3)
        {
            enemyStateMachine.ChangeState(ghostsm.patrolState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        ghostsm.agent.SetDestination(ghostsm.target.position);

        Vector3 direction = ghostsm.target.position - ghostsm.enemy.transform.position;

        ghostsm.enemy.transform.rotation = Quaternion.Slerp(ghostsm.enemy.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

        if (Vector3.Distance(ghostsm.target.position, ghostsm.enemy.transform.position) <= 0.15)
        {
            PlayerHealth.health -= 1;
        }
    }
}
