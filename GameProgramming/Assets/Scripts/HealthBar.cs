using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHealth(int health) // this is called to set the max health Bar 
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health) // this is called to set the healthBar
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); 
    }

}
