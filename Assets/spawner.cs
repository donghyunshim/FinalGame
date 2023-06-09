using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy111;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public Transform enemypos1;
    public Transform enemypos2;
    public Transform enemypos3;
    public Transform enemypos4;
    public Transform enemypos5;
    public Transform enemypos6;
    private float repeatRate = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Check");
        if (other.gameObject.tag == "Playertag")
        {
            Debug.Log("HIT");
            Destroy(gameObject);
            Instantiate(enemy111, enemypos1.position, enemypos1.rotation);
            Instantiate(enemy2, enemypos2.position, enemypos2.rotation);
            Instantiate(enemy3, enemypos3.position, enemypos3.rotation);
            Instantiate(enemy4, enemypos4.position, enemypos4.rotation);
            Instantiate(enemy5, enemypos5.position, enemypos5.rotation);
            Instantiate(enemy6, enemypos6.position, enemypos6.rotation);
        }
    }
}
