using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player is sprinting
/// </summary>
public class PlayerRunningState : State<PlayerController>
{
	public PlayerRunningState(PlayerController controller, StateMachine<PlayerController> stateMachine) : base(controller, stateMachine)
	{
	}
}
