using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    EnemyBaseState currentState;

    private void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateLogic();
        }
    }

    private void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
        }
    }

    public void ChangeState(EnemyBaseState newState)
    {
        currentState.Exit();

        currentState = newState;

        newState.Enter();
    }

    protected virtual EnemyBaseState GetInitialState()
    {
        return null;
    }
}
