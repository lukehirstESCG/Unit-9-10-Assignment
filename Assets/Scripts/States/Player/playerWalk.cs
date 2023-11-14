using UnityEngine;

public class playerWalk : PlayerBaseState
{
    float horizontalInput;
    float verticalInput;
    private PlayerMovementSM pacsm;

    public playerWalk(PlayerMovementSM playerStateMachine) : base ("Walk", playerStateMachine)
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

        horizontalInput = pacsm.pacJoy.Horizontal;
        verticalInput = pacsm.pacJoy.Vertical;
        float direction = new Vector2(horizontalInput, verticalInput).magnitude;

        if (direction <= 0.01f)
        {
            playerStateMachine.ChangeState(pacsm.idleState);
            pacsm.pacAnim.SetBool("walk", false);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        // Player (Pacman) logic

        pacsm.rotation = new Vector3(0, pacsm.pacJoy.Horizontal * pacsm.rotationSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, pacsm.pacJoy.Vertical * Time.deltaTime);
        move = pacsm.transform.TransformDirection(move);
        pacsm.pacman.Move(move * pacsm.speed);
        pacsm.transform.Rotate(pacsm.rotation);

        // Camera Logic
        pacsm.camera.transform.position = pacsm.player.transform.position;
        pacsm.camera.rotation = pacsm.player.rotation;
    }
}
