using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    private Slider slider;
    [SerializeField] Health health;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        health.OnUpdateSliderHealth += UpdateSlider;
    }

    public void UpdateSlider(float newValue)
    {
        if (newValue < 0) throw new ArgumentException($"Argument amount {nameof(newValue)} is negativ");
        if (newValue > 1) throw new ArgumentException($"Argument amount {nameof(newValue)} is > 1");

        slider.value = newValue;
    }
}
