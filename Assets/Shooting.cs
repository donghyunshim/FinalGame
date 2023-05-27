using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float bulletforce = 20f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        //spawn bullet and name it bullet
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

        //access bullet and get its rigid body
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        //use rigidbody to addforce at firepoint using bulletforce in impulse style
        rb.AddForce(FirePoint.up * bulletforce, ForceMode2D.Impulse); 
    }
}
