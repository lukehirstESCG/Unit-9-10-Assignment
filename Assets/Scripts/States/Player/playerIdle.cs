using UnityEngine;

public class playerIdle : PlayerBaseState
{
    private PlayerMovementSM pacsm;
    float horizontalInput;
    float verticalInput;

    public playerIdle(PlayerMovementSM playerStateMachine) : base("Idle", playerStateMachine)
    {
        pacsm = playerStateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        horizontalInput = 0;
        verticalInput = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        horizontalInput = pacsm.joystick.Horizontal;
        verticalInput = pacsm.joystick.Vertical;
        float direction = new Vector2(horizontalInput, verticalInput).magnitude;

        if (direction > 0.01f)
        {
            playerStateMachine.ChangeState(pacsm.walkState);
            pacsm.anim.SetBool("walk", true);
        }
    }
}