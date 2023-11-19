using UnityEditor.Rendering;
using UnityEngine;

public class playerMoving : PlayerBaseState
{
    float horizontalInput;
    float verticalInput;
    float turnSmoothVelocity;
    Vector3 direction;
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
        direction = new Vector3(horizontalInput, 0, verticalInput);

        if (direction.magnitude <= 0.01)
        {
            playerStateMachine.ChangeState(playsm.idleState);
            playsm.anim.SetBool("moving", false);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playsm.playerCam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(playsm.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, playsm.turnSmoothTime);
        playsm.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        move = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        playsm.control.Move(move.normalized * playsm.speed * Time.deltaTime);
    }
}
