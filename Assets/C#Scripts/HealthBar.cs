using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Transform tm;
    public Transform parentTransform;
    public Slider Slider;
    public Color Low;
    public Color High;
    public Image Image;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<Transform>();
        tm.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        if (tm != null && parentTransform != null)
        {
            tm.position = parentTransform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Image.color = Color.Lerp(Low, High, health/maxHealth);
    }
}
