using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector] public StateMachine<PlayerController> stateMachine = new StateMachine<PlayerController>();
    [HideInInspector] public PlayerIdleState playerIdleState;

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

        playerIdleState = new PlayerIdleState(this, stateMachine);
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
