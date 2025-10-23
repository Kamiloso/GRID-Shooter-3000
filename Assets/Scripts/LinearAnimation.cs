using UnityEngine;

public class LinearAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 movingSpeed;
    [SerializeField] private Vector3 rotationSpeed;
    [SerializeField] private bool randomRotationDirection;

    private Rigidbody rb;
    private int rtSgn;

    // Attach this script to an object with a Rigidbody
    // (isKinematic = true, interpolation = Interpolate)

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null || !rb.isKinematic)
        {
            Debug.LogError("Please attach a Rigidbody component and make it kinematic.");
            Destroy(this);
            return;
        }

        rtSgn = (randomRotationDirection && UnityEngine.Random.Range(0, 2) == 1) ? -1 : 1;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movingSpeed * Time.fixedDeltaTime);

        Quaternion newRotation = Quaternion.Euler(rb.rotation.eulerAngles + rtSgn * rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(newRotation);
    }
}
