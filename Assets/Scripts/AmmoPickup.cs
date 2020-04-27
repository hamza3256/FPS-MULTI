using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

    public bool isPicked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AmmoUI>().addCurrentAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
            isPicked = true;
            Debug.Log("Ammo picked up");
        }
    }
}
