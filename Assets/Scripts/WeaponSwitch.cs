using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public int equippedWeapon = 0;

    public static bool isAuto;

    public static bool switched;

    // Start is called before the first frame update
    void Start()
    {
        isAuto = true;
        equipWeapon();
        switched = false;
    }

    // Update is called once per frame
    void Update()
    {
        int previousequippedWeapon = equippedWeapon;
        
        // select weapon using scroll wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f )
        {
            if (equippedWeapon >= transform.childCount - 1)
                equippedWeapon = 0;
            else
                equippedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (equippedWeapon <= 0 )
                equippedWeapon = transform.childCount - 1;
            else
                equippedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equippedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
        {
            equippedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 )
        {
            equippedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4 )
        {
            equippedWeapon = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            equippedWeapon = 4;
        }

        if (previousequippedWeapon != equippedWeapon)
        {
            equipWeapon();
        }

        if(equippedWeapon == 2 || equippedWeapon == 3 || equippedWeapon == 4)
        {
            isAuto = false;
        }
        else
        {
            isAuto = true;
        }
    }

    void equipWeapon ()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            switched = true;
            if (i == equippedWeapon )
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

}
