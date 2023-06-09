using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;

    public Player player;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Playertag");
        player = go.GetComponent<Player>();
    }
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag != "EnemyElement" )
        {
            if (collision.tag == "Playertag")
            {
                if (player.state == Player.State.Normal)
                {
                    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                    Destroy(effect, .24f);
                    Destroy(gameObject);
                }
            }
            else
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, .24f);
                Destroy(gameObject);
            }
        }
    }
}
