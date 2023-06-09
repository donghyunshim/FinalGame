using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public GameObject hitEffect;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player") {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, .24f);
            Destroy(gameObject);
        }
        
    }
}
