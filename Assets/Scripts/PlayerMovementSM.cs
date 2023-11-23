using UnityEngine;

public class PlayerMovementSM : PlayerStateMachine
{
    public float speed = 100;
    public float rotationSpeed;
    public CharacterController control;
    public Transform player;
    public Transform playerCam;
    public VariableJoystick joystick;
    public Animator anim;
    public Vector3 direction;
    public Vector3 rotation;

    [HideInInspector]
    public playerIdle idleState;
    [HideInInspector]
    public playerWalk movingState;

    private void Awake()
    {
        idleState = new playerIdle(this);
        movingState = new playerWalk(this);
    }

    protected override PlayerBaseState GetInitialState()
    {
        return idleState;
    }
}