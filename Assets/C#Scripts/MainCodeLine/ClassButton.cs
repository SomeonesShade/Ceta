using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassButton : MonoBehaviour
{
    public int classIndex;
    public UiUpgradeData UUD;
    public ClassDisplay CD;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(ClickEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ClickEvent()
    {
        UUD.ChangeClass(classIndex);
        CD.Removal();
    }
}
