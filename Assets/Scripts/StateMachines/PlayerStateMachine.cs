using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerBaseState currentState;

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null )
        {
            currentState.Enter();
        }
    }

    void Update()
    {
        if (currentState != null )
        {
            currentState.UpdateLogic();
        }
    }
    void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
        }
    }

    public void ChangeState(PlayerBaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        newState.Enter();
    }

    protected virtual PlayerBaseState GetInitialState()
    {
        return null;
    }
}
