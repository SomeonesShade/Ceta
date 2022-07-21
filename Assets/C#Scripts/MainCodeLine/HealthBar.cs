using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Related: BodyMechanics
//Displays the UI of BodyMechanics, But Also...
//Handles the Position of The MiniBar which is a pain
public class HealthBar : MonoBehaviour
{
    Transform tm;
    public Transform parentTransform;
    public Slider Slider;
    public Color Low;
    public Color High;
    public Image Image;
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        tm = GetComponent<Transform>();
        tm.SetParent(null); //im not your child now hehe
    }//Because dont want to rotate

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
    {//Runs in BodyMechanics Update
        if (health >= maxHealth - 0.1f)
        {
            Slider.gameObject.SetActive(false);
            isActive = false;
        }
        Slider.value = health;
        Slider.maxValue = maxHealth;
        Image.color = Color.Lerp(Low, High, health/maxHealth);
    }
    public IEnumerator Activate(float health, float maxHealth, bool isPlayer)
    {//Runs when BodyMechanics signals thatits been dealt damage
        if (isPlayer)
        {
            Slider.gameObject.SetActive(health < maxHealth);
            yield return null;
        }
        else
        {
            if (!isActive)
            {
                isActive = true;
                Slider.gameObject.SetActive(true);
                yield return new WaitForSeconds(5);
                Slider.gameObject.SetActive(false);
                isActive = false;
            }
        }
        yield return null;
    }
}
