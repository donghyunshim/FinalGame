using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float Followspeed = 2f;
    public Transform target;
    Vector2 mousePos;
    public Camera cam;

    public float offsetx = .1f;
    public float offsety = .14f;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = new Vector3((target.position.x + mousePos.x * offsetx) / 1, (target.position.y + mousePos.y * offsety) / 1, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, Followspeed * Time.deltaTime);
    }
}
