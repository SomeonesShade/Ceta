using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider; //the GUI affected
    private float targetProgress; //remaining_exp/how_many_exp_needed
    
    public float timeToLevel;
    public int level; //local level
    public int previousLevel;
    public float[] maxP; //how much exp needs per lvl
    
    private float remainingEXP; //what remains
    private float sliderValue; //it is a %percentage
    // Start is called before the first frame update
    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        previousLevel = level;
    }

    void Start()
    {
        sliderValue = slider.value;
    }
    // Update is called once per frame
    void Update()
    {
        Increment();
    }
    //AAAAAAAAAAAAAAAAAA
    public void IncrementProgress(float newP)
    {
        //total xp - xp going to get taken
        remainingEXP = newP + (sliderValue * maxP[level]) - maxP[level];
        //target progress meanwhile is just the percentage of totalexp/exprequiredtolevel
        targetProgress = sliderValue + newP/maxP[level];
        while(remainingEXP >= 0)
        {
            level += 1;
            //remaining exp/newlevelexprequired
            targetProgress = remainingEXP/maxP[level];
            //remainingexp updated
            remainingEXP = remainingEXP - maxP[level];
        }
        remainingEXP += maxP[level]; //makes it the actual remaining exp
        //ishould update the slider value after it resolves gotcha
        sliderValue = remainingEXP/maxP[level];
        Debug.Log("Remaining EXP: " + remainingEXP);
        Debug.Log("Current SliderValue: " + sliderValue);
    }
    public int ReportLevel()
    {
        return level;
    }
    private void Increment()
    {
        //Note toself need to have a slight delay on computing? idk
        //Adding Temporary && false to stop the slow increase, and see if its the problem
        //if a level up is needed
        if(previousLevel != level)
        {
            //if you are not at maxvalue
            if (slider.value + Time.deltaTime < 1)
            {
                slider.value += Time.deltaTime;
            } //set to max if you cant add more
            else
            {
                slider.value = 0;
                previousLevel += 1;
            }
        }
        //otherwise slide the thing...
        else
        {
            if (slider.value + targetProgress/timeToLevel * Time.deltaTime < targetProgress)
            {
                slider.value += targetProgress/timeToLevel * Time.deltaTime;
            }
            else
            {
                slider.value = targetProgress;
            }
        }
    }
    public void Reset()
    {
        targetProgress = 0;
        level = 1;
        previousLevel = 1;
        remainingEXP = 0;
        sliderValue = 0;
        slider.value = 0;
    }
}
