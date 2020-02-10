using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    private int _buttonNumber;
    private ButtonsManager _buttonsManager;
    private string _text;

    private void Awake()
    {
        _buttonsManager = transform.parent.GetComponent<ButtonsManager>();
        Int32.TryParse(Regex.Match(name, @"\d+").Value, out _buttonNumber);
        _text = GetComponentInChildren<Text>().text;
        _text = _text.Split(' ').First();
    }

    public void OnClick()
    {
        _buttonsManager.SetActiveButton(_buttonNumber, _text);
    }

    public void OnNextClick()
    {
        _buttonsManager.Next();
    }


}
