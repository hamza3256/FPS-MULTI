using UnityEngine;
using UnityEngine.AI;

/**
 * 
 * Script that is used on enemy prefabs (zombies)
 * 
 * */
public class EnemyAI : MonoBehaviour
{
    // Get reference to the player
    [SerializeField]
    Transform targetPlayer;

    // Range that we can detect the player
    [SerializeField]
    float visionRange = 8f;

    // Speed at which we turn
    [SerializeField]
    float turnSpeed = 5f;

    // Reference to the NavMeshAgent on this component
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    // Reference to the EnemyHealth script component
    EnemyHealth HP;

    // Allows us to call a method once if we are dead, don't call it again
    private bool isDead = false;

    void Start()
    {
        // Get reference to the NavMeshAgent and the HP of the Zombies
        navMeshAgent = GetComponent<NavMeshAgent>();
        HP = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        // If our HP reached zero and we didn't die before, then run
        if (HP.ZeroHPCheck() && !isDead)
        {
            // Make sure our navmesh and ourself is disabled
            isDead = true;
            enabled = false;
            navMeshAgent.enabled = false;

            // Move the position of the zombie corpse towards the terrain since the animation's pivot is on the centre of the object rather than the feet
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            transform.position = newPosition;
        }


        // Get the distance to the player
        distanceToTarget = Vector3.Distance(targetPlayer.position, transform.position);

        // If i'm in vision range, engage the player
        if (distanceToTarget <= visionRange)
        {
            EngageTarget();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            int num = Random.Range(1, 3);
            FindObjectOfType<AudioManager>().PlaySound("Zombie_Attack_" + num);

            FindObjectOfType<PlayerHealth>().HealthDamage(25);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerHealth>().HealthDamage(2);

            int num = Random.Range(1, 3);
            FindObjectOfType<AudioManager>().PlaySound("Zombie_Attack_" + num);
        }
    }


    // Engages the player
    private void EngageTarget()
    {
        int num = Random.Range(1, 4);
        FindObjectOfType<AudioManager>().PlaySound("Zombie_Idle_" + num);


        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance && !HP.ZeroHPCheck())
        { 
            EnemyTrigger();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    // Moves and plays the attack animation towards the player
    private void EnemyTrigger()
    {
        GetComponent<Animator>().SetBool("attackZ", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(targetPlayer.position);
    }

    // Play the attack animation while attacking the player
    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attackZ", true);
        Debug.Log(name + " has seeked and is attacking " + targetPlayer.name);
    }

    // Method that allows us to rotate and face the player
    private void FaceTarget()
    {
        Vector3 facingDirection = (targetPlayer.position - transform.position).normalized;
        Quaternion changeRotation = Quaternion.LookRotation(new Vector3(facingDirection.x, 0, facingDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, changeRotation, Time.deltaTime * turnSpeed);
    }

}
