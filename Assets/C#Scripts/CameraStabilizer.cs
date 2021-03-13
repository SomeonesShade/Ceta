using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStabilizer : MonoBehaviour
{
    private Transform tm;
    private Quaternion StartRotation;
    void Awake()
    {
        tm = GetComponent<Transform>();
        StartRotation = tm.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tm.rotation = StartRotation
    }
}
