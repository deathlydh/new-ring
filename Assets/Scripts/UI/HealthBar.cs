using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;  // —сылка на слайдер

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        healthSlider.value = Mathf.Clamp01(currentHealth / maxHealth);
    }
}
