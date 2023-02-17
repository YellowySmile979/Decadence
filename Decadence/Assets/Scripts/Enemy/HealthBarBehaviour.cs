using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slide;
    public Color low;
    public Color high;
    public Vector3 offset;

    public Slider ReloadSlide;
    public Vector3 ReloadOffset;

    private void Update()
    {
        slide.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        ReloadSlide.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + ReloadOffset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        slide.gameObject.SetActive(health < maxHealth);
        slide.value = health;
        slide.maxValue = maxHealth;

        slide.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slide.normalizedValue);
    }
    public void SetReload (float time, float MaxTime)
    {
        ReloadSlide.gameObject.SetActive(time > 0);
        ReloadSlide.value = time;
        ReloadSlide.maxValue = MaxTime;
    }
}
