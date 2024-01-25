using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalHealth : MonoBehaviour
{
    public float MaxHealth;
    public float Health;
    public bool IsDead;
   
    public Chooser choice;

    private void Start()
    { 
        Health = MaxHealth;
    }

    public void Set_Max_Health(float Hp)
    {
        Health = Hp;

    }


    public void Apply_Damage(float damage)
    {
        Health -= damage;

        if (Health <= 0 && !IsDead)
        {

            IsDead = true;

        }
        
    }






}
public enum Chooser
{
    Player,
    Enemy,
}