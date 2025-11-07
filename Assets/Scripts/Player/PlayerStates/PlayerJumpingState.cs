using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player jumped and is in the air
/// </summary>
public class PlayerJumpingState : State<PlayerController>
{
	public PlayerJumpingState(PlayerController controller, StateMachine<PlayerController> stateMachine) : base(controller, stateMachine)
	{
	}
}
