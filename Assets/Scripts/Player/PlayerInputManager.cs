using Assets.Scripts.Player.Interfaces;
using UnityEngine;

/// <summary>
/// Takes care of all player input and distributes it.
/// This is the place that you want to stop from ticking when game is paused.
/// </summary>
public class PlayerInputManager : MonoBehaviour
{
	private PlayerMovement playerMovement;
	private IPlayerCamera playerCamera;

	private void Start()
	{
		playerMovement = GetComponent<PlayerMovement>();
		playerCamera = playerMovement.GetComponent<IPlayerCamera>();
	}

	void Update()
	{
		//if(gameObject is paused) return;

		// set Sprinting before movement
		playerMovement.Sprint = Input.GetButton("Sprint");
		// Moves the player
			playerMovement.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
		// Makes the player jump
		if (Input.GetButtonDown("Jump"))
			playerMovement.Jump();
		// mouse camera movement
		float horizontalRotation = Input.GetAxis("Mouse X");
		float verticalRotation = Input.GetAxis("Mouse Y");
		playerCamera.RotateCamera(horizontalRotation, verticalRotation);
	}
}
