using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float Followspeed = 2f;
    public Transform target;
    Vector2 mousePos;
    public Camera cam;

    public float offsetx = 0;
    public float offsety = 0;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = new Vector3(target.position.x, target.position.y , -5f);
        transform.position = Vector3.Slerp(transform.position, newPos, Followspeed * Time.deltaTime);
    }
}
