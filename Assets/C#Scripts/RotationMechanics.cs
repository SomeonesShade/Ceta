using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMechanics : MonoBehaviour
{
    private Transform tm;
    private Vector2 mouseLocation;
    private Vector2 relPos;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        relPos = mouseLocation - new Vector2(tm.position.x, tm.position.y);
        angle = Mathf.Atan2(relPos.y, relPos.x) * Mathf.Rad2Deg;
        tm.rotation = Quaternion.Euler(0,0,angle);
    }
}
