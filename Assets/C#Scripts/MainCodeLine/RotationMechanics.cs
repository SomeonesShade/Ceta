using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Related: Self Contained
//Interacts ONLY with the Player's Rotation and Mouse Position
public class RotationMechanics : MonoBehaviour
{
    private Transform tm;
    private Vector2 mouseLocation, relPos;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);//locate the mouse
        relPos = mouseLocation - new Vector2(tm.position.x, tm.position.y); //relative distance from the mousetoplayer
        angle = Mathf.Atan2(relPos.y, relPos.x) * Mathf.Rad2Deg;            //no idea, just converts the vector into an angle
        tm.rotation = Quaternion.Euler(0,0,angle);                          //then converts it into a quaternion and sets the rotation!
    }
}
