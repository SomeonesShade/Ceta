using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatCounter : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    public string textType;
    public int Size;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = textType + Size;
    }
    public void Updater(int size)
    {
        Size = size; // lets get the data and display
    }
}
