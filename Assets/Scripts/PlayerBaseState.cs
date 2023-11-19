using UnityEngine;

public class PlayerBaseState : MonoBehaviour
{
    public string name;
    protected PlayerStateMachine playerStateMachine;

    public PlayerBaseState(string name, PlayerStateMachine playerStateMachine)
    {
        this.name = name;
        this.playerStateMachine = playerStateMachine;
    }

    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}
