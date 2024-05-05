using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera ecamera;
    [SerializeField] private Transform etarget;
    [SerializeField] private Vector3 eoffset;
    
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value= currentValue / maxValue;
    }
    
    void Update()
    {
        transform.rotation = ecamera.transform.rotation;
        transform.position = ecamera.WorldToScreenPoint(etarget.position + eoffset);
    }
}
