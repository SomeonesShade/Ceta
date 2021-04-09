using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMechanics : MonoBehaviour
{
    //public Transform parentTransform;
    private Transform tm;
    public bool First;
    private Transform prevParentTransform;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        //tm = GetComponent<Transform>();
        //if(First)
        //{
        //    prevParentTransform = parentTransform;
        //}
        //else
        //{
        //    parentTransform = prevParentTransform;
        //}
        //tm.rotation = parentTransform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
