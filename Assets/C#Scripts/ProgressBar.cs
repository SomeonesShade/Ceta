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
    // Start is called before the first frame update
    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        previousLevel = level;
    }

    void Start()
    {
        IncrementProgress(11, 2);
    }
    // Update is called once per frame
    void Update()
    {
        Increment();
    }
    public void IncrementProgress(float newP, float maxP)
    {
        targetProgress = slider.value + newP/maxP;
        while(targetProgress >= 1)
        {
            targetProgress -= 1;
            level += 1;
        }
    }
    private void Increment()
    {
        if(previousLevel != level)
        {
            if (slider.value + Time.deltaTime < 1)
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
}
