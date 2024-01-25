using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.FuzzyWindow;

public class Enemy : MonoBehaviour
{
    public float DistanceBetweenPlayerAndEnemy = 0;
    public Transform Player;
    public  UniversalHealth Health;
    public float Damage = 0;
    public float Range;
    // Update is called once per frame
  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, Range);
    }
    void Update()
    {
       DistanceBetweenPlayerAndEnemy = Vector3.Distance(gameObject.transform.position, Player.position);

  


        if(DistanceBetweenPlayerAndEnemy < Range)
        {
            Damage = 30 / DistanceBetweenPlayerAndEnemy;
        }
    }




   

}
