using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//Related: ProgressBar
//Displays the Level from ProgressBar
//Potential Intermediate Variables? idk
public class LevelDisplay : MonoBehaviour
{
    private TextMeshProUGUI tmp; //self explanitory just displays the level
    public ProgressBar pb;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "Level: " + pb.displayedLevel;
    }
}
