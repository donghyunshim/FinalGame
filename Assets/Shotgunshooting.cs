using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ShotgunShooting : MonoBehaviour
{
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform FirePoint3;
    public Transform FirePoint4;
    public Transform FirePoint5;

    public GameObject bulletPrefab;
    public float bulletforce = 20f;

    // ammo

    public int defaultammo = 2;
    public int currentAmmo = 2;

    public float reloadSpeed = 1.5f;

    [HideInInspector]
    public bool needReload;

    //Audio
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void Start()
    {
        currentAmmo = defaultammo;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentAmmo <= 0)
        {
            if (needReload)
            {
                return;
            }
            else
            {
                needReload = true;
                StartCoroutine(Reload());
            }
        }
        else if (Input.GetButtonDown("Fire1") && !needReload)
        {
            Shoot();
        }

    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        currentAmmo = defaultammo;
        needReload = false;
    }

    void Shoot()
    {
        audioManager.PlaySFX(audioManager.shotgunsound);
        currentAmmo = currentAmmo - 1;
        //spawn bullet and name it bullet
        GameObject bullet1 = Instantiate(bulletPrefab, FirePoint1.position, FirePoint1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, FirePoint2.position, FirePoint2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, FirePoint3.position, FirePoint3.rotation);
        GameObject bullet4 = Instantiate(bulletPrefab, FirePoint4.position, FirePoint4.rotation);
        GameObject bullet5 = Instantiate(bulletPrefab, FirePoint5.position, FirePoint5.rotation);

        //access bullet and get its rigid body
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
        Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();

        //use rigidbody to addforce at firepoint using bulletforce in impulse style
        rb1.AddForce(FirePoint1.up * bulletforce, ForceMode2D.Impulse);
        rb2.AddForce(FirePoint2.up * bulletforce, ForceMode2D.Impulse);
        rb3.AddForce(FirePoint3.up * bulletforce, ForceMode2D.Impulse);
        rb4.AddForce(FirePoint4.up * bulletforce, ForceMode2D.Impulse);
        rb5.AddForce(FirePoint5.up * bulletforce, ForceMode2D.Impulse);

    }
}
