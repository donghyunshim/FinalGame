using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPhysicsIgnorer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col2d)
    {
        if (col2d.collider.name == "TempEnemy")
        {
            Physics2D.IgnoreCollision(col2d.collider, col2d.otherCollider);
        }
    }
}

