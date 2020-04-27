using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationManager : MonoBehaviour
{
   

    public Animator animator;

    
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude >= 0.1)
        {
            animator.SetBool("walking", true);
          
        }
        else
        {
            animator.SetBool("walking", false);
            
        }

    }

    
}
