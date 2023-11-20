using UnityEngine;

public class playerIdle : PlayerBaseState
{
    private PlayerMovementSM playsm;
    float horizontalInput;
    float verticalInput;
    float direction;

    public playerIdle(PlayerMovementSM playerStateMachine) : base("Idle", playerStateMachine)
    {
        playsm = playerStateMachine;
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

        horizontalInput = playsm.joystick.Horizontal;
        verticalInput = playsm.joystick.Vertical;
        direction = new Vector2(horizontalInput, verticalInput).magnitude;

        if (direction > 0.01f)
        {
            playerStateMachine.ChangeState(playsm.movingState);
            playsm.anim.SetBool("moving", true);
        }
    }
}
