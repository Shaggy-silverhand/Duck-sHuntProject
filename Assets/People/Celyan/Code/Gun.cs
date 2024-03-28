using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;

    public float bulletSpeed = 10;

    public float countdown = 1;

    public float initialValue = 1;

    [SerializeField] public Animator GunAnim;


    private void FixedUpdate()
    {
        GunAnim.SetBool("Shoot", false);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GunAnim.SetBool("Shoot", true);
        }
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        

    }
    
       
    
}