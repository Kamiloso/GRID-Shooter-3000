using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Health))]

public class Player : MonoBehaviour
{
    public PlayerController controller { get; private set; }
    public Health health { get; private set; }

    protected void Awake()
    {
        controller = GetComponent<PlayerController>();
        health = GetComponent<Health>();
    }   
}
