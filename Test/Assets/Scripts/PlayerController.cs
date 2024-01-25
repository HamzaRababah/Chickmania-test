using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float sprintSpeed;
    public Transform Camera_Follow;
    public CharacterController Player_controller;
    public bool IsMoving;
    public GameObject Bullet;
    public Transform shootFrom;
    public Rigidbody BulletRB;

    public void Start()
    {
       
    }

    void shooting()
    {
        if(Input.GetButtonDown("Fire1"))
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
    
        GameObject Curr_Bullet = Instantiate(Bullet, shootFrom.transform.position, shootFrom.transform.rotation);
        Curr_Bullet.transform.SetParent(shootFrom, false);
        Curr_Bullet.transform.localPosition = Vector3.zero;
        Curr_Bullet.transform.parent = null;
        Curr_Bullet.transform.rotation = shootFrom.rotation;

        BulletRB = Curr_Bullet.GetComponent<Rigidbody>();

        BulletRB.AddForce(Curr_Bullet.transform.forward * 10, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);

     
    }
    void Update()
    {


        shooting();

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));



        var oldRot = transform.rotation;
        var Target_Rotation = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + Camera_Follow.eulerAngles.y;
        var new_rot = Quaternion.Euler(0f, Target_Rotation, 0f);

        transform.rotation = Quaternion.Lerp(oldRot, new_rot, 10f * Time.deltaTime);
        Vector3 Move_Direction = Quaternion.Euler(0f, Target_Rotation, 0f) * Vector3.forward;
     
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

         if(moveDirection!= Vector3.zero)
        Player_controller.Move(Move_Direction * Time.deltaTime * moveSpeed);
        
    }
}
