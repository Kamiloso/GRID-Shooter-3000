using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;

    public int MaxHelath { get => maxHealth; set => maxHealth = value; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void GetDmg(int dmg, int duration)
    {
        if (duration > 1)
        {
            ApplyDamageOverTime(dmg, duration);
        }
        else
        {
            ReduceHealth(dmg);
        }
    }

    private void ReduceHealth(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public void ApplyDamageOverTime(int dmg, int duration)
    {
        StartCoroutine(DamageOverTimeCoroutine(dmg, duration));
    }

    private IEnumerator DamageOverTimeCoroutine(int dmg, int duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            ReduceHealth(dmg);
            yield return new WaitForSeconds(0.5f);
            elapsed += 1f;
        }
    }

    public void Heal(int amound)
    {
        currentHealth += amound;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void IncreaseMaxHelath(int amound)
    {
        maxHealth += amound;
        Heal(amound);
    }

    public void FullRegenerateHealth()
    {
        currentHealth = maxHealth;
    }
}
