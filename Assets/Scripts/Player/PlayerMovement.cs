using UnityEngine;


/// <summary>
/// Controlls player movement (but not the player input)
/// </summary>
public class PlayerMovement : MonoBehaviour
{
	#region Movement
	[SerializeField]
	private float movementSpeed = 5.0f;
	[SerializeField]
	private float dragInAir = 0.1f;
	[SerializeField]
	private float dragOnGround = 5.0f;
	[SerializeField]
	private float sprintSpeedMultiplier = 1.5f;
	[SerializeField]
	private float jumpHeight = 1.0f;
	[SerializeField]
	private float gravityValue = -9.81f;
	[SerializeField]
	private int additionalJumps = 1;
	#endregion
	public bool Sprint { get; set; }

	#region private
	private CharacterController controller;
	/// <summary>
	/// Player is on ground
	/// </summary>
	public bool Grounded => controller.isGrounded;
	private bool groundedPlayer;

	/// <summary>
	/// used for gravity and jumping
	/// </summary>
	private Vector3 velocity;
	private int additionalJumpsDone;
	#endregion
	// Start is called before the first frame update
	private void Start()
	{
		controller = GetComponent<CharacterController>();
		velocity = Vector3.zero; //reset velocity
		Sprint = false;
	}

	/// <summary>
	/// Moves the player in the direction he is looking by the moveVector
	/// </summary>
	/// <param name="moveVector">is rescaled here by Speed and Time.deltaTime</param>
	public void Move(Vector2 moveVector)
	{
		groundedPlayer = Grounded;
		if (dragInAir < 0) dragInAir *= -1;
		if (dragInAir < 0.1) dragInAir = 0.1f;

		Vector3 move = Vector3.zero;
		if (moveVector != Vector2.zero)
		{
			move = (transform.forward * moveVector.y) + (transform.right * moveVector.x);
			move *= movementSpeed * Time.deltaTime;
			if (Sprint)
				move *= sprintSpeedMultiplier;
		}
		controller.Move(move);

		float applyDrag = 1 - ((groundedPlayer ? dragOnGround : dragInAir) * Time.deltaTime);
		if (applyDrag < 0.1f) applyDrag = 0.1f;
		velocity.x *= applyDrag;
		velocity.z *= applyDrag;
		if (Mathf.Abs(velocity.x) < 0.05) velocity.x = 0; //stop forever sliding
		if (Mathf.Abs(velocity.y) < 0.05) velocity.y = 0;

		velocity.y += gravityValue * Time.deltaTime; //apply gravity

		controller.Move(velocity * Time.deltaTime); //execute apply velocity


		if (groundedPlayer)
		{
			additionalJumpsDone = 0;
			if (velocity.y < 0)
			{
				velocity.y = 0f;
			}
		}
	}

	/// <summary>
	/// Performs: regular jump if on ground; additional jump if in air
	/// </summary>
	public void Jump()
	{
		bool doJump = false;
		if (groundedPlayer)
			doJump = true;
		else if (additionalJumpsDone < additionalJumps)
		{
			doJump = true;
			++additionalJumpsDone;
		}
		if (doJump)
			velocity.y = Mathf.Sqrt(jumpHeight * (-2f * gravityValue)); //gravity is negative so we multiply by -2 to have positive value to sqrt
	}
	/// <summary>
	/// Adds velocity x,z and sets the y component (couse of Gravity)
	/// </summary>
	/// <param name="velocity">velocity to add</param>
	public void AddVelocity(Vector3 velocity)
	{
		this.velocity += velocity;
		this.velocity.y = velocity.y;
	}

}
