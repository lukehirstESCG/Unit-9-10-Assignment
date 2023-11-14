using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementSM : PlayerStateMachine
{
    public float speed;
    public float rotationSpeed;
    public CharacterController pacman;
    public Joystick pacJoy;
    public Transform player;
    public Transform camera;
    public Animator pacAnim;
    public Vector3 direction;
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
