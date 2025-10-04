using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        if (health > 60)
        {
            fill.color = Color.green;
        }
        else if (health > 30)
        {
            fill.color = Color.yellow;
        }
        else
        {
            fill.color = Color.red;
        }
    }
}
