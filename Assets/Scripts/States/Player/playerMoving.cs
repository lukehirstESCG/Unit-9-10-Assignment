using UnityEngine;

public class playerMoving : PlayerBaseState
{
    float horizontalInput;
    float verticalInput;
    float direction;
    Vector3 move;
    private PlayerMovementSM playsm;

    public playerMoving(PlayerMovementSM playerStateMachine) :base("Moving", playerStateMachine)
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

        if (direction <= 0.01)
        {
            playerStateMachine.ChangeState(playsm.idleState);
            playsm.anim.SetBool("moving", false);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        playsm.rotation = new Vector3(0, playsm.joystick.Horizontal * playsm.rotationSpeed * Time.deltaTime, 0);

        move = new Vector3(0, 0, playsm.joystick.Vertical * Time.deltaTime);
        playsm.control.Move(move * playsm.speed);
        playsm.transform.Rotate(playsm.rotation);

        playsm.playerCam.transform.position = playsm.transform.position;
        playsm.playerCam.rotation = playsm.player.rotation;
    }
}
