using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerBaseState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
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
