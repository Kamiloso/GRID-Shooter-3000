using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State<PlayerController>
{
	public PlayerAttackState(PlayerController controller, StateMachine<PlayerController> stateMachine) : base(controller, stateMachine)
	{
	}

}
