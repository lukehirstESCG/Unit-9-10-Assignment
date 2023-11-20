using UnityEngine;

public class playerWalk : PlayerBaseState
{
    float horizontalInput;
    float verticalInput;
    float direction;
    private PlayerMovementSM playsm;
    public playerWalk(PlayerMovementSM playerStateMachine) : base("Moving", playerStateMachine)
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

        if (direction < 0.01f)
        {
            playerStateMachine.ChangeState(playsm.idleState);
            playsm.anim.SetBool("moving", false);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        playsm.rotation = new Vector3(0, playsm.joystick.Horizontal * playsm.rotationSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, playsm.joystick.Vertical * Time.deltaTime);
        move = playsm.transform.TransformDirection(move);
        playsm.control.Move(move * playsm.speed * Time.deltaTime);
        playsm.transform.Rotate(playsm.rotation);

        playsm.playerCam.transform.position = playsm.transform.position;
        playsm.playerCam.rotation = playsm.player.rotation;
    }
}