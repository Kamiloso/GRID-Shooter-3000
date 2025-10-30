using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : State<PlayerController>
{
	public PlayerRunningState(PlayerController controller, StateMachine<PlayerController> stateMachine) : base(controller, stateMachine)
	{
	}
}
