using UnityEngine;

public class PlayerMovementSM : PlayerStateMachine
{
    public float speed = 5;
    public float rotationSpeed;
    public CharacterController control;
    public Transform player;
    public Transform cam;
    public Joystick joystick;
    public Animator anim;
    [HideInInspector]
    public Vector3 direction;
    [HideInInspector]
    public Vector3 rotation;

    [HideInInspector]
    public playerIdle idleState;
    [HideInInspector]
    public playerWalk walkState;

    private void Awake()
    {
        idleState = new playerIdle(this);
        walkState = new playerWalk(this);
    }

    protected override PlayerBaseState GetInitialState()
    {
        return idleState;
    }
}
