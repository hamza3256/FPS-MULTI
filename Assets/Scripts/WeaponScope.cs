using UnityEngine;
using UnityEngine.UI;

/**
 * Script which handles the weapon scoping, pressing the Fire2 button (usually the right mouse button) 
 * will enable the 'isScoped' bool of the animator, which will in turn move our camera to the scoped position
 * **/
public class WeaponScope : MonoBehaviour
{
    public Animator animator;
    private Image reticle;
    public static bool isScoped = false;

    

    void Start()
    {
        GameObject img = GameObject.FindWithTag("reticle");
        reticle = img.GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        // pressed right mouse button?
        if (Input.GetButtonDown("Fire2"))
        {
            
            // make sure isScoped is now the opposite of what it was
            isScoped = !isScoped;


            reticle.enabled = !isScoped;

           
            // tell the animator that we are what isScoped is
            animator.SetBool("isScoped", isScoped);
        }
    }
}
