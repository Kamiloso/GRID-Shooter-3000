using System;
using System.Threading.Tasks;
using UnityEngine;

public class StateMachine<T> where T : MonoBehaviour
{
    public State<T> CurrentState { get; private set; }

    private Action _updateState;
    private Action _fixedUpdateState;
    private Action _lateUpdateState;

    public void Initialize(State<T> startingState)
    {
        if (startingState == null) throw new ArgumentNullException(nameof(startingState));

        CurrentState = startingState;
        CacheDelegates(startingState);

        startingState.EnterState();
    }

    public void ChangeState(State<T> newState)
    {
        if (newState == null) throw new ArgumentNullException(nameof(newState));
        if (newState == CurrentState) return;

        var oldState = CurrentState;

        oldState?.ExitState();
        CurrentState = newState;
        CacheDelegates(newState);
        newState.EnterState();
    }

    private void CacheDelegates(State<T> state)
    {
        _updateState = (Action)state.UpdateState ?? EmptyMethod;
        _fixedUpdateState = (Action)state.FixedUpdateState ?? EmptyMethod;
        _lateUpdateState = (Action)state.LateUpdateState ?? EmptyMethod;
    }

    private static void EmptyMethod() { }

    public void UpdateState() => _updateState();
    public void FixedUpdateState() => _fixedUpdateState();
    public void LateUpdateState() => _lateUpdateState();
}