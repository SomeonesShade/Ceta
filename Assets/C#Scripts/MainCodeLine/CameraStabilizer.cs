using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This may get deleted/changed, considering i can just attach this to Ghost

//Related: Self Contained
//Uses the Ghosts Location To Follow the Player (if not dead)
//We need the Ghost to maintain Camera View
//(First Time Intermediate Variables are Useful Here)
public class CameraStabilizer : MonoBehaviour
{
    private Transform tm;
    public Transform otherTm;
    private Quaternion StartRotation;
    void Awake()
    {
        otherTm = GameObject.FindGameObjectWithTag("Ghost").GetComponent<Transform>();
        tm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tm.position = new Vector3(
            otherTm.position.x,
            otherTm.position.y,
            tm.position.z); //sets the position of the camera
    }
}
