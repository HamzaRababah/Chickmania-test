using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootFrom;
    public Rigidbody BulletRB;
    [SerializeField] private float fireRate = 2;
    private float nextFire;


    private int numberOfBullets = 1;
    private int currentShot;
    private GameObject[] bullets;
   // public GameObject Bullet;

    public bool DidShoot;


    private void Start()
    {
        //bullets = new GameObject[numberOfBullets];

        //currentShot = 0;

        /*for (int i = 0; i < numberOfBullets; i++)
        {
            bullets[i] = Instantiate(bullet, shootFrom.position, shootFrom.rotation);
            bullets[i].SetActive(false);
        }*/

        DidShoot = true;

}

    private void Update()
    {
        /*if (currentShot == bullets.Length)
        {
            Debug.Log("Out of bullets <-_->");
            
            this.enabled = false;
            return;
        }*/
        if (DidShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        /* nextFire -= Time.deltaTime;

         if (nextFire <= 0)
         {
             nextFire += fireRate;

             bullets[currentShot].SetActive(true);
             currentShot++;
         }*/

        /* Instantiate(bullet, shootFrom.position, shootFrom.rotation);
         DidShoot = false;
         
         DidShoot = true;*/

        GameObject Curr_Bullet = Instantiate(bullet, shootFrom.transform.position, shootFrom.transform.rotation);
        Curr_Bullet.transform.SetParent(shootFrom, false);
        Curr_Bullet.transform.localPosition = Vector3.zero;
        Curr_Bullet.transform.parent = null;
        Curr_Bullet.transform.rotation = shootFrom.rotation;

        BulletRB = Curr_Bullet.GetComponent<Rigidbody>();

        BulletRB.AddForce(Curr_Bullet.transform.forward * 10, ForceMode.Impulse);
        DidShoot = false;
        yield return new WaitForSeconds(fireRate);
        DidShoot=true;

    }


}
