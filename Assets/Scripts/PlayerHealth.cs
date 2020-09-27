using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float baseLives = 3f;
    [SerializeField] Text playerHealthText;
    float playerHealth = 10f;
    [SerializeField] float attackerDamage = 1f;

    private void Start()
    {
        playerHealth = baseLives - PlayerPrefsController.GetDifficulty();
        playerHealthText.text = playerHealth.ToString();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Destroy(otherCollider.gameObject, 2f);
        DamagePlayer();
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        playerHealthText.text = playerHealth.ToString();

        if (playerHealth <= 0)
        {
            playerHealthText.text = "0";
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

    private void DamagePlayer()
    {
        playerHealth -= attackerDamage;
    }
}
