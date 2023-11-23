using UnityEngine;

public class playerIdle : PlayerBaseState
{
    private PlayerMovementSM playsm;
    float horizontalInput;
    float verticalInput;
    Vector3 direction;
    float magnitude;

    public playerIdle(PlayerMovementSM playerStateMachine) : base("Idle", playerStateMachine)
    {
        playsm = playerStateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        horizontalInput = 0;
        verticalInput = 0;
        playsm.speed = 100;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        horizontalInput = playsm.joystick.Horizontal;
        verticalInput = playsm.joystick.Vertical;
        direction = new Vector3(horizontalInput, 0, verticalInput);
        magnitude = direction.magnitude;
        magnitude = Mathf.Clamp01(magnitude);

        if (direction.magnitude > 0.01f)
        {
            playerStateMachine.ChangeState(playsm.movingState);
            playsm.anim.SetBool("moving", true);
        }
    }
}
