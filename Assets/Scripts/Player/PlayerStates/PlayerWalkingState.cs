using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player is active in game and not idle. Can walk around at any time.
/// </summary>
public class PlayerWalkingState : State<PlayerController>
{
	public PlayerWalkingState(PlayerController controller, StateMachine<PlayerController> stateMachine) : base(controller, stateMachine)
	{
	}

	public override void EnterState()
	{
		base.EnterState();
	}

	public override void ExitState()
	{
		base.ExitState();
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
	}

	public override void LateUpdateState()
	{
		base.LateUpdateState();
	}

	public override void UpdateState()
	{
		base.UpdateState();
	}
}
