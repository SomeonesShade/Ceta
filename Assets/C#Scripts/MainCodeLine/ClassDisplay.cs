using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassDisplay : MonoBehaviour
{
    public GameObject prefabButton;
    public Transform p1, p2;
    public GameObject[] prefabDisplay;
    Vector2 displayDimensions;
    float prefabDiameter, prefabAmount;
    // Start is called before the first frame update
    //Too Much?
    void Awake()
    {
        displayDimensions = p2.position - p1.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayNow(GameObject[] nextUpgrades)
    {
        SpriteMaker(nextUpgrades);
        Placement(nextUpgrades);
    }
    void SpriteMaker(GameObject[] objects)
    {
        foreach(GameObject obj in objects)
        {
            MonoBehaviour[] components = obj.GetComponents<MonoBehaviour>();
            MonoBehaviour[] childComponents = obj.GetComponentsInChildren<MonoBehaviour>();
            foreach(MonoBehaviour c in components)
            {
                if(c.GetType() == typeof(SpriteRenderer))
                {
                    continue;
                }
                c.enabled = false;
            }
            foreach(MonoBehaviour c in childComponents)
            {
                if(c.GetType() == typeof(SpriteRenderer))
                {
                    continue;
                }
                c.enabled = false;
            }
        }
    }
    void Placement(GameObject[] objects)
    {
        Vector2 temp = new Vector2(prefabDiameter, -prefabDiameter),
            halfDiagonal = new Vector2(-prefabDiameter/2, prefabDiameter/2);
        foreach(GameObject obj in objects)
        {   
            if(temp.x > displayDimensions.x)
            {
                temp.x = prefabDiameter;
                temp.y -= prefabDiameter;
            }
            Instantiate(prefabButton, temp + halfDiagonal, Quaternion.identity);
            Instantiate(obj, temp + halfDiagonal, Quaternion.identity);
            temp.x += prefabDiameter;
        }
    }
    void Removal()
    {

    }
}
