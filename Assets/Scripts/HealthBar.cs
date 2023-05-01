using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider healthBarSlider;

    public void SetSlider(float value)
    {
        healthBarSlider.value = value;
    }

    public void SetSliderMax(float value)
    {
        healthBarSlider.maxValue = value;
        SetSlider(value);
    }
}
