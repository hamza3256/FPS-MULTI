using UnityEngine;

/**
 * (Incomplete script)
 * Script that is used when attacking the player
 * */
public class EnemyAttack : MonoBehaviour
{

    PlayerHealth targetPlayer;
    [SerializeField]
    int damage = 40;

    void Start()
    {
        // Get the players health
        targetPlayer = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (targetPlayer == null) return;
        targetPlayer.HealthDamage(damage);
        Debug.Log("Enemy is attacking");
    }
} 
