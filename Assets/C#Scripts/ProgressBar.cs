using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float targetProgress;
    public float timeToLevel;
    public int level;
    public int previousLevel;
    public float[] maxP;
    private float newEXP;
    private float sliderValue;
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
    //AAAAAAAAAAAAAAAAAAA
    public void IncrementProgress(float newP)
    {
        newEXP = newP - maxP[level] + (sliderValue * maxP[level]);
        targetProgress = sliderValue + newP/maxP[level];
        while(targetProgress >= 1)
        {
            Debug.Log("activated!" + targetProgress);
            level += 1;
            targetProgress = newEXP/maxP[level];
            newEXP = newEXP - maxP[level];
        }
        Debug.Log(newEXP + maxP[level]);
    }
    public int ReportLevel()
    {
        return level;
    }
    private void Increment()
    {
        //Adding Temporary && false to stop the slow increase, and see if its the problem
        if(previousLevel != level)
        {
            if (slider.value + Time.deltaTime < 1 && false)
            {
                slider.value += Time.deltaTime;
            }
            else
            {
                slider.value = 0;
                previousLevel += 1;
            }
        }
        else
        {
            if (slider.value + targetProgress/timeToLevel * Time.deltaTime < targetProgress  && false)
            {
                slider.value += targetProgress/timeToLevel * Time.deltaTime;
            }
            else
            {
                slider.value = targetProgress;
                sliderValue = slider.value;
            }
        }
    }
}
