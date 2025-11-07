using Assets.Scripts.Player.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Is responsible for updating player camera
/// </summary>
public class PlayerCameraMouse : MonoBehaviour, IPlayerCamera
{
	// Camera Rotation
	[SerializeField]
	private float mouseSensitivityX = 2f;
	[SerializeField]
	private float mouseSensitivityY = 2f;

	private float _verticalRotation;
	private Transform cameraTransform;


	void Start()
	{
		cameraTransform = Camera.main.transform;
		_verticalRotation = cameraTransform.localRotation.eulerAngles.x;
		// Hides the mouse
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	/// <summary>
	/// Implements IPlayerCamera for Mouse movement version
	/// </summary>
	/// <param name="horizontalRotation"></param>
	/// <param name="verticalRotation"></param>
	public void RotateCamera(float horizontalRotation, float verticalRotation)
	{
		horizontalRotation *= mouseSensitivityX;
		transform.Rotate(0, horizontalRotation, 0);

		_verticalRotation -= verticalRotation * mouseSensitivityY;
		_verticalRotation = Mathf.Clamp(_verticalRotation, -90f, 90f);

		cameraTransform.localRotation = Quaternion.Euler(_verticalRotation, 0, 0);
	}
}
