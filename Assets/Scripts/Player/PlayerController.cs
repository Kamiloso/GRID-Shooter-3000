using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	#region StateMachine
	[HideInInspector] public StateMachine<PlayerController> stateMachine = new StateMachine<PlayerController>();
	[HideInInspector] public PlayerIdlingState playerIdleState;
	[HideInInspector] public PlayerWalkingState walkingState;
	[HideInInspector] public PlayerJumpingState jumpingState;
	#endregion

	private Player player;

	private Rigidbody rb;
	public Rigidbody Rb { get => rb; set => rb = value; }

	[Header("Idle")]
	public float velocity;
	public float jumpForce;

	private void Awake()
	{
		player = GetComponent<Player>();

		rb = GetComponent<Rigidbody>();

		playerIdleState = new PlayerIdlingState(this, stateMachine);
		walkingState = new PlayerWalkingState(this, stateMachine);
		jumpingState = new PlayerJumpingState(this, stateMachine);
	}

	private void Start()
	{
		stateMachine.Initialize(playerIdleState);
	}

	private void Update()
	{
		stateMachine.UpdateState();
	}

	private void FixedUpdate()
	{
		stateMachine.FixedUpdateState();
	}

	private void LateUpdate()
	{
		stateMachine.LateUpdateState();
	}

}
