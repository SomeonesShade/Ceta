using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceCount : MonoBehaviour
{
    public int type;
    Data_InstanceCounter localData;
    void Awake()
    {
        localData = GameObject.FindGameObjectWithTag("DATA").GetComponent<Data_InstanceCounter>();
        localData.IntToAmount(type)++;
    }
    void OnDestroy()
    {
        if(localData != null)
        {
            localData.IntToAmount(type)--;
        }
    }
}
