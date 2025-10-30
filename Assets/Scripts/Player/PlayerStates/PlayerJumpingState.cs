using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : State<PlayerController>
{
	public PlayerJumpingState(PlayerController controller, StateMachine<PlayerController> stateMachine) : base(controller, stateMachine)
	{
	}
}
