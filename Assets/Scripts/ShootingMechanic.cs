using UnityEngine;
using System.Collections;
/**
 * Script which handles the shooting mechanics in the game, 
 * such as pressing down the left mouse button and then shooting at enemies, 
 * and handling the damage towards those enemies
 * */
public class ShootingMechanic : MonoBehaviour
{

    public WeaponRecoil recoil;

   // public AnimationClip shootMechanism;

    [SerializeField]
    Camera FPCamera;

    [SerializeField]
    float range = 100f;

    [SerializeField]
    float damage = 30f;

    [SerializeField]
    public int maxAmmo = 30;

    [SerializeField] AmmoUI ammoSlot;

    [SerializeField] AmmoType ammoType;

    public float reloadTime = 1f;
    private bool isReloading = false;
   
    [SerializeField]
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;
    public float impactForce = 60f;

    [SerializeField]
    ParticleSystem muzzleFlash;


    [SerializeField]
    GameObject hitEffect;

    AudioSource shootingSound;
    

    [SerializeField]
    public bool autoMode;
    

    [SerializeField] public AmmoDisplay ammoDisplay;

    public Animator animator;

    public int ammoCount;
    public int clipCount;

    //public AmmoPickup ammoPickup;

    void Start()
    {
        // Get the sound of the gun component passed
        shootingSound = GetComponent<AudioSource>();
        ammoCount = ammoSlot.GetCurrentAmmo(ammoType);
        updateClip(ammoCount);
        updateAmmo();
       // ammoPickup.isPicked = false;
    }

    void updateClip(int ammoCount)
    {
        if (ammoType.ToString() == "ACP")
        {
            if (ammoCount >= 25)
            {
                clipCount = ammoCount - 25;
            }
            else
            {
                clipCount = 0;
            }
            
        }
        if (ammoType.ToString() == "Gauge")
        {
            if (ammoCount >= 12)
            {
                clipCount = ammoCount - 12;
            }
            else
            {
                clipCount = 0;
            }
        }
        if (ammoType.ToString() == "Rifle")
        {
            if (ammoCount >= 35)
            {
                clipCount = ammoCount - 35;
            }
            else
            {
                clipCount = 0;
            }
        }
        if (ammoType.ToString() == "Magnum")
        {
            if (ammoCount >= 7)
            {
                clipCount = ammoCount - 7;
            }
            else
            {
                clipCount = 0;
            }
        }

        if (clipCount > 0)
        {
            ammoDisplay.UpdateClipCount(clipCount);
        }
        else
        {
            ammoDisplay.UpdateClipCount(0);
        }
    }

    void updatePickupClip()
    {
            ammoDisplay.UpdateClipCount(clipCount+5);
            ammoDisplay.UpdateAmmoCount(ammoCount-5);   
    }

    void updateAmmo()
    {
        if (ammoType.ToString() == "ACP")
        {
            ammoDisplay.UpdateAmmoCount(8);
        }
        if (ammoType.ToString() == "Gauge")
        {
            ammoDisplay.UpdateAmmoCount(12);

        }
        if (ammoType.ToString() == "Rifle")
        {
            ammoDisplay.UpdateAmmoCount(35);
        }
        if (ammoType.ToString() == "Magnum")
        {
            ammoDisplay.UpdateAmmoCount(7);

        }
    }


    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
        // ammodisplay.updateammocount(ammoslot.getcurrentammo(ammotype));
        // ammodisplay.updateammotype(ammotype);
        
    }
    void Update()
    {
        ammoCount = ammoSlot.GetCurrentAmmo(ammoType);

        ammoDisplay.UpdateAmmoCount(ammoCount-clipCount);

        ammoDisplay.UpdateAmmoType(ammoType);

        autoMode = WeaponSwitch.isAuto;
        
       // if (ammoPickup.isPicked)
        //{
         //   updatePickupClip();
          //  ammoPickup.isPicked = false;
        //}

        if (WeaponSwitch.switched)
        {
            updateClip(ammoCount);
            WeaponSwitch.switched = false;
        }

        if (isReloading)
            return;

        if (((ammoCount-clipCount) <= 0 || Input.GetKeyDown(KeyCode.R)) && ammoCount >0)
        {
            StartCoroutine(Reload());
            return;
        }
        // Did we click the Fire1 button? (usually mouse left click)
        if (ammoCount > 0)
        {
            if (!autoMode)
            {
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {

                    // Play the gun sound when shooting
                    shootingSound.Play();
                    animator.SetBool("shooting", true);
                    recoil.Fire();
                    nextTimeToFire = Time.time + 1f / fireRate;
                    
                    PlayMuzzleFlash();
                    ShootGun();
                }
            }
            else
            {
                if ((Input.GetButton("Fire1") || Input.GetButtonDown("Fire1")) && Time.time >= nextTimeToFire)
                {
                    // Play the gun sound when shooting
                    shootingSound.Play();
                    animator.SetBool("shooting", true);
                    recoil.Fire();
                    nextTimeToFire = Time.time + 1f / fireRate;
                    
                    ShootGun();
                }
            }
        }
        
    }


    IEnumerator Reload()
    {
        isReloading = true;
        ammoCount = ammoSlot.GetCurrentAmmo(ammoType);
        updateClip(ammoCount);
        Debug.Log("Reloading...");

       animator.SetBool("reload", true);
        //animator.SetTrigger("reload");
        animator.SetBool("shooting", false);
        yield return new WaitForSeconds(reloadTime + .45f);
        
        //yield return new WaitForSeconds(reloadTime);

       animator.SetBool("reload", false);

        yield return new WaitForSeconds(.25f);

      
        isReloading = false;
    }

    // Shoots the gun
    private void ShootGun()
    {
        
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            RaycastProcessing();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        
       
    }

    // Plays a particle of muzzleFlash when shooting
    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
     
    // Method which calculates the projectile shots and seeing if we hit anything, 
    // if we did hit anything then get the targetPlayer (the enemies) health and damage it
    private void RaycastProcessing()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);
            
            EnemyHealth targetPlayer = hit.transform.GetComponent<EnemyHealth>();
            //GameObject zombie = GameObject.FindWithTag("zombie");
            if (targetPlayer != null  )
            {
                targetPlayer.HealthDamage(damage);
                
            }
            
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            
            //InstantiateHitImpact(hit);

        }
        else
        {
            return;
        }
    }

    // Create a hit impact GameObject then destroy it after
    private void InstantiateHitImpact(RaycastHit hit)
    {
      
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        
        Destroy(impact);
   
    }

    
}
 