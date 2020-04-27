using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/**
 * Script that manages the players health
 * 
 * currently has a method that can damage the players health by a value
 * 
 * 
 * */
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;

    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    


    public void HealthDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        Debug.Log(currentHealth);
        if (maxHealth <= 0)
        {
            Debug.Log("Health is zero. You are dead.");
        }
    }
}
