using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePresets : MonoBehaviour
{
    [Header("Child Positions")]
    public Transform p1, p2;
    [Header("Preset")]
    public GameObject preset1;
    public float TimeDuration;
    public int MaxObjects;
    float currentTime;
    Transform tr;
    int objectType;
    Data_InstanceCounter data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("DATA").GetComponent<Data_InstanceCounter>();
        objectType = preset1.GetComponent<InstanceCount>().type;
        tr = this.gameObject.GetComponent<Transform>();
    }

    Vector2 nullVector = new Vector2(0,0);
    const float radius = 2f;
    void Spawner()
    {
        Vector2 temp = new Vector2(0,0);
        for(int a = 0;Physics2D.CircleCast(temp,radius,nullVector) && a < 4;a++)
        {
            temp.x = Random.Range(p1.position.x,p2.position.x);
            temp.y = Random.Range(p1.position.y,p2.position.y);
        }
        Instantiate(preset1, temp, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        int size = data.IntToAmount(objectType);
        currentTime -= Time.deltaTime;
        if(currentTime <= 0 && size < MaxObjects)
        {
            currentTime = TimeDuration;
            Spawner();
        }
    }
}
