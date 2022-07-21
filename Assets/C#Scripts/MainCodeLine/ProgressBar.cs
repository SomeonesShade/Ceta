using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Related: SoulSystem, UpgradeSystem, and LevelDisplay
//This is A Complicated One It handles how the exp data is represented
//This requires intimate connection with Ups as it needs the Level and EXP to function
public class ProgressBar : MonoBehaviour
{
    public int Level
        {private get{return level;} set{level = value;}}
    public int DisplayedLevel
        {get{return displayedLevel;} private set{displayedLevel = (value > level)? level : value;}}
    public float TimeToLevel
        {private get{return timeToLevel;} set{timeToLevel = (value < 0.0001f)? 0.0002f : value;}}
    [SerializeField] int level;
    [SerializeField] int displayedLevel;
    [SerializeField] float timeToLevel;
    Slider slider; //the GUI affected
    float targetSliderValue; //remaining_exp/how_many_exp_needed
    //Updates if a value is changed in the inspector or loading in
    void OnValidate()
    {
        Level = level;
        DisplayedLevel = displayedLevel;
    }
    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        DisplayedLevel = Level;
    }

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Increment();
    }
    public void ReportVariables(float rEXP, float maxPoint, int currentLevel)
    {
        targetSliderValue = rEXP/maxPoint;
        Level = currentLevel;
    }
    private void Increment()
    {
        //if a level up is needed
        if(DisplayedLevel != Level)
        {
            //are we not overshooting?
            if (slider.value + Time.deltaTime < 1)
            {
                slider.value += Time.deltaTime;
            }
            else// otherwise update the levels
            {
                slider.value = 0;
                DisplayedLevel += 1;
            }
        }
        //otherwise slide the thing...
        else
        {//Does it not Overshoot?
            if (slider.value + targetSliderValue/TimeToLevel * Time.deltaTime < targetSliderValue)
            {
                slider.value += targetSliderValue/TimeToLevel * Time.deltaTime;
            }
            else // otherwise just set the same
            {
                slider.value = targetSliderValue;
            }
        }
    }
    public void Reset()
    {
        targetSliderValue = 0;
        Level = 1;
        DisplayedLevel = 1;
        slider.value = 0;
    }
}
