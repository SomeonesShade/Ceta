using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Related: DATA, UpgradeSystem, and ClassMechanics
//Handles when Changing Class ANd Making Sure Nothing Breaks w/ Transfering Data
public class ClassChange : MonoBehaviour
{
    public GameObject[] classPrefabs;
    public GameObject Child;
    GameObject DATA;
    int a;
    void Awake() 
    {
        DATA = GameObject.FindGameObjectWithTag("DATA");
        classPrefabs = DATA.GetComponent<Data_ClassBranches>().Prefabs;        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            a = (a + 1) % classPrefabs.Length;
            ChangeClass(a);
        }
    }
    public void ChangeClass(int index)
    {
        Destroy(Child);
        Child = Instantiate(classPrefabs[index],
            Vector2.zero,
            new Quaternion(0,0,0,0));
        Child.GetComponent<Transform>().SetParent(this.transform,false);
        ClassMechanics childCM = Child.GetComponent<ClassMechanics>();
        childCM.Parent = this.gameObject;
        childCM.UpS = this.gameObject.GetComponent<UpgradeSystem>();
    }
    public void ChangeClass(GameObject upgrade)
    {
        Destroy(Child);
        Child = Instantiate(upgrade,
            Vector2.zero,
            new Quaternion(0,0,0,0));
        Child.GetComponent<Transform>().SetParent(this.transform,false);
        ClassMechanics childCM = Child.GetComponent<ClassMechanics>();
        childCM.Parent = this.gameObject;
        childCM.UpS = this.gameObject.GetComponent<UpgradeSystem>();
    }
}
