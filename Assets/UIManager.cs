using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button btn;
    public TMP_InputField inputField;
    public Toggle toggle;
    public Slider slider;

    void Update()
    {
        
    }

    public void OnBtnClkEvent()
    {
        print(inputField.text);
        print(toggle.isOn);
        print(slider.value);
    }
}
