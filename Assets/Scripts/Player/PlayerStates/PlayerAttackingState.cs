using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player is attacking
/// </summary>
public class PlayerAttackingState : State<PlayerController>
{
	public PlayerAttackingState(PlayerController controller, StateMachine<PlayerController> stateMachine) : base(controller, stateMachine)
	{
	}

}
