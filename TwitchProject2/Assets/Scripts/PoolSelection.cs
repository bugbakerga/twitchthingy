using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolSelection : MonoBehaviour
{
    public float settingValue;
    public Slider slider;

    public string settingname;
    public Text settingText;

    void Start()
    {
        settingValue = PlayerPrefs.GetFloat(settingname, slider.minValue);
        slider.value = settingValue;
    }

    public void SliderInput(float value)
    {
        settingValue = value;
        settingText.text = settingValue.ToString();
        PlayerPrefs.SetFloat(settingname, settingValue);
    }

    public void AddUnit()
    {
        if(settingValue < slider.maxValue)
        {
            settingValue += 1;
        }
        else
        {
            settingValue = slider.maxValue;
        }
        slider.value = settingValue;
        settingText.text = settingValue.ToString();
        PlayerPrefs.SetFloat(settingname, settingValue);
    }

    public void SubtractUnit()
    {
        if(settingValue > slider.minValue)
        {
            settingValue -= 1;
        }
        else
        {
            settingValue = slider.minValue;
        }
        slider.value = settingValue;
        settingText.text = settingValue.ToString();
        PlayerPrefs.SetFloat(settingname, settingValue);
    }
}
