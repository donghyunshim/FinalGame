using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsIgnorer : MonoBehaviour
{
    private void Start()
    {
        GameObject TempEnemy = GameObject.FindGameObjectWithTag("EnemyElement");
        Physics2D.IgnoreCollision(TempEnemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
