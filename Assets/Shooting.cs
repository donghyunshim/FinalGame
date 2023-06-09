using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint1;
    

    public GameObject bulletPrefab;
    public float bulletforce = 20f;

    // ammo

    public int defaultammo = 6;
    public int currentAmmo = 6;

    public float reloadSpeed = 2f;

    [HideInInspector]
    public bool needReload;

    private void Start()
    {
        currentAmmo = defaultammo;
    }

    //Audio
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
        else if (Input.GetKeyDown(KeyCode.R)){

            needReload = true;
            StartCoroutine(Reload());
        }
        else if(Input.GetButtonDown("Fire1") && !needReload)
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
        audioManager.PlaySFX(audioManager.pistolsound);
        currentAmmo = currentAmmo - 1;
        //spawn bullet and name it bullet
        GameObject bullet1 = Instantiate(bulletPrefab, FirePoint1.position, FirePoint1.rotation);
 

        //access bullet and get its rigid body
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();


        //use rigidbody to addforce at firepoint using bulletforce in impulse style
        rb1.AddForce(FirePoint1.up * bulletforce, ForceMode2D.Impulse);


    }
}
