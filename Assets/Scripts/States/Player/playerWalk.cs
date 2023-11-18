using UnityEngine;

public class playerWalk : PlayerBaseState
{
    float horizontalInput;
    float verticalInput;
    private PlayerMovementSM pacsm;

    public playerWalk(PlayerMovementSM playerStateMachine) : base("Walk", playerStateMachine)
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

        if (direction <= 0.01)
        {
            playerStateMachine.ChangeState(pacsm.idleState);
            pacsm.anim.SetBool("walk", false);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        // Player (Pacman) logic

        pacsm.rotation = new Vector3(0, pacsm.joystick.Horizontal * pacsm.rotationSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, pacsm.joystick.Vertical * Time.deltaTime);
        move = pacsm.transform.TransformDirection(move);
        pacsm.control.Move(move * pacsm.speed);
        pacsm.transform.Rotate(pacsm.rotation);

        // Camera Logic
        pacsm.cam.transform.position = pacsm.transform.position;
        pacsm.cam.rotation = pacsm.player.rotation;
    }
}