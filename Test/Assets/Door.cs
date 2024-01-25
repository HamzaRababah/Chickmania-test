using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    public Animator Anim;
    

    public void Interact()
    {
        
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("DoorClose"))
        {
            Anim.SetBool("DoorOpen", true);
            
        }

        else if (Anim.GetCurrentAnimatorStateInfo(0).IsName("DoorOpened"))
        {
            Anim.SetBool("DoorOpen", false);
     
        }


    }
}
