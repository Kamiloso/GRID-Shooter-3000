using System.Threading.Tasks;
using UnityEngine;

public abstract class State<T> where T : MonoBehaviour
{
    protected readonly T controller;
    protected readonly StateMachine<T> stateMachine;

    protected State(T controller, StateMachine<T> stateMachine)
    {
        this.controller = controller;
        this.stateMachine = stateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }


    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }
    public virtual void LateUpdateState() { }
}
