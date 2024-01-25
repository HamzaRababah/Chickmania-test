using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLight : MonoBehaviour,IInteractable
{
    public Animator Anim;
    public Light LightBulb;
    
   public void Interact()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("LeverOff"))
        {
            Anim.SetBool("Lever", true);
            LightBulb.intensity = 5;      
        }

        else if (Anim.GetCurrentAnimatorStateInfo(0).IsName("LeverOn"))
        {
            Anim.SetBool("Lever", false);
            LightBulb.intensity = 0;
        }
     

    }


}
