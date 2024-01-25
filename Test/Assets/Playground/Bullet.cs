using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody rb;
    public Enemy Enemy;
    public EntityType type;
    private void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        if(type == EntityType.enemy)
        Enemy = FindAnyObjectByType<Enemy>();
   
    }
    void Update()
    {
          
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        var Damaged = other.GetComponentInParent<UniversalHealth>();
        float DamageDealt = 0;
        if(other.tag == "Front")
        {
            if (type == EntityType.enemy)
            {
                Damaged.Apply_Damage(Enemy.Damage);
                DamageDealt = Enemy.Damage;
            }
            else if (type == EntityType.player)
            {
                Damaged.Apply_Damage(10);
                DamageDealt = 10;
                
            }
            Destroy(gameObject);

        }
        if (other.tag == "Back")
        {
            if (Enemy.DistanceBetweenPlayerAndEnemy <= 3)
            {
                Damaged.Apply_Damage(Enemy.Damage * 2);
                DamageDealt = Enemy.Damage *2;
            }
            else
            {
                Damaged.Apply_Damage(Enemy.Damage);
                DamageDealt = Enemy.Damage;
            }
            Destroy(gameObject);
        }

        Debug.Log("Damage dealt "+DamageDealt+" remaining health "+ Damaged.Health);
    }



    private void Move()
    {
        //transform.Translate(speed * Time.deltaTime * transform.forward,Space.World);
  
    }
}
public enum EntityType{
    player,
    enemy,
}