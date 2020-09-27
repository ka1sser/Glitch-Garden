using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float startingHealth = 100f;
    [SerializeField] float currentHealth = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
            currentHealth = startingHealth;
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 0.2f);
    }
}
