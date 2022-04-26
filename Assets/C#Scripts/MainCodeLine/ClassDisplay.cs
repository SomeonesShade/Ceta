using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
//This needs a revamp :/ might be too overkill...
public class ClassDisplay : MonoBehaviour
{
    public GameObject prefabButton;
    List<GameObject> buttons = new List<GameObject>();
    public Transform p1, p2;
    public GameObject[] prefabDisplay;
    Vector2 displayDimensions;
    float prefabDiameter, prefabAmount;
    RectTransform prefabTr;
    public UiUpgradeData UUD;
    // Start is called before the first frame update
    //Too Much?
    void Awake()
    {
        displayDimensions = p2.position - p1.position;
        prefabTr = prefabButton.GetComponent<RectTransform>();
        prefabDiameter = Mathf.Max(prefabTr.rect.height, prefabTr.rect.width);
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
        Debug.Log("Display in Action");
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
        int i = 0;
        foreach(GameObject obj in objects)
        {   
            if(temp.x > displayDimensions.x)
            {
                temp.x = prefabDiameter;
                temp.y -= prefabDiameter;
            }
            GameObject button = Instantiate(prefabButton, 
                temp + halfDiagonal, 
                Quaternion.identity, 
                this.transform);
                Debug.Log("Button Made");
                Debug.Log(temp.x + " , " + temp.y);
            button.GetComponent<ClassButton>().classIndex = i;
            button.GetComponent<ClassButton>().UUD = UUD;
            button.GetComponent<ClassButton>().CD = this.gameObject.GetComponent<ClassDisplay>();
            buttons.Add(button);
            Instantiate(obj, 
                temp + halfDiagonal, 
                Quaternion.identity, 
                button.transform);
            temp.x += prefabDiameter;
            i++;
        }
    }
    public void Removal()
    {
        foreach(GameObject g in buttons)
        {
            Destroy(g);
        }
        buttons.Clear();
    }
}
