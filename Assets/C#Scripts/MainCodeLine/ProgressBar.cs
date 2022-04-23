using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Related: SoulSystem, UpgradeSystem, and LevelDisplay
//This is A Complicated One It handles how the exp data is represented
//This requires intimate connection with Ups as it needs the Level and EXP to function
public class ProgressBar : MonoBehaviour
{
    public float timeToLevel;
    public int level,
        displayedLevel;
    Slider slider; //the GUI affected
    float targetSliderValue; //remaining_exp/how_many_exp_needed
    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        displayedLevel = level;
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
        level = currentLevel;
    }
    private void Increment()
    {
        //if a level up is needed
        if(displayedLevel != level)
        {
            //are we not overshooting?
            if (slider.value + Time.deltaTime < 1)
            {
                slider.value += Time.deltaTime;
            }
            else// otherwise update the levels
            {
                slider.value = 0;
                displayedLevel += 1;
            }
        }
        //otherwise slide the thing...
        else
        {//Does it not Overshoot?
            if (slider.value + targetSliderValue/timeToLevel * Time.deltaTime < targetSliderValue)
            {
                slider.value += targetSliderValue/timeToLevel * Time.deltaTime;
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
        level = 1;
        displayedLevel = 1;
        slider.value = 0;
    }
}
