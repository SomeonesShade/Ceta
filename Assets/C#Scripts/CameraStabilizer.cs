using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStabilizer : MonoBehaviour
{
    private Transform tm;
    public Transform otherTm;
    private Quaternion StartRotation;
    void Awake()
    {
        tm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tm.position = new Vector3(otherTm.position.x,
        otherTm.position.y,
        tm.position.z);
    }
}
