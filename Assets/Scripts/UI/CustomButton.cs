using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    private int _buttonNumber;
    private ButtonsManager _buttonsManager;

    private void Awake()
    {
        _buttonsManager = transform.parent.GetComponent<ButtonsManager>();
        Int32.TryParse(Regex.Match(name, @"\d+").Value, out _buttonNumber);
    }

    public void OnClick()
    {
        _buttonsManager.SetActiveButton(_buttonNumber);
    }

    public void OnNextClick()
    {
        _buttonsManager.Next();
    }


}
