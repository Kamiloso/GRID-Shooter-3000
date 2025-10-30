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

	/// <summary>
	/// Called every frame to update the current state.
	/// </summary>
	public virtual void UpdateState() { }
	/// <summary>
	/// Called at FixedUpdate to update the current state.
	/// </summary>
	public virtual void FixedUpdateState() { }
	/// <summary>
	/// Called at LateUpdate to update the current state.
	/// </summary>
	public virtual void LateUpdateState() { }
}
