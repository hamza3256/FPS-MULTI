using UnityEngine;

/**
 * Script that is used to check on the enemies health, things such as if we have died (reaching a health of 0)
 * 
 * */
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float health = 100f;


     bool zeroHPCheck = false;

    // public getter for return the value of zeroHPCheck
    public bool ZeroHPCheck()
    {
        return zeroHPCheck;
    }
    

    // Damage this enemies health by the damage value passed in
    public void HealthDamage(float damage)
    {
        health -= damage;
        GetComponent<Animator>().SetTrigger("damage");
        if (health <= 0f)
        {
            Die();
        }
    }

    // If we are dying then play the dying animation
    void Die()
    {
        GameObject zombie = GameObject.FindWithTag("zombie");
        if (zeroHPCheck)
         {
             return;
         }
        
        zeroHPCheck = true;
       
        
        GetComponent<Animator>().SetTrigger("death");
        GetComponent<CapsuleCollider>().enabled = false;
        if (gameObject != null )
        {
            Destroy(gameObject,2.5f);
        }
        
    }
}
