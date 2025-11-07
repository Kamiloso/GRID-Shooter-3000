using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchOnEnterControler : MonoBehaviour
{
    [SerializeField] private Vector3 enterImpulse;
    [SerializeField] private bool resetXAxis;
    [SerializeField] private bool resetYAxis;
    [SerializeField] private bool resetZAxis;

    private void OnTriggerEnter(Collider other)
    {
		PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
		if (playerMovement != null)
			playerMovement?.AddVelocity(enterImpulse);

		Rigidbody rb = other.attachedRigidbody;
		if (rb != null)
        {
            Vector3 oldPos = rb.velocity;
            rb.velocity = new Vector3( // yes, that's the recommended way
                resetXAxis ? 0f : oldPos.x,
                resetYAxis ? 0f : oldPos.y,
                resetZAxis ? 0f : oldPos.z
                );
            rb.AddForce(enterImpulse, ForceMode.Impulse);
        }
    }
}
