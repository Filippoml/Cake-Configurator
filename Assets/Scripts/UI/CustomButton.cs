using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    public bool IsActive { get; set; }
    public int ButtonNumber;
    public string Text { get; set; }


    private ButtonsManager _buttonsManager;

    private void Awake()
    {
        _buttonsManager = transform.parent.GetComponent<ButtonsManager>();
        Int32.TryParse(Regex.Match(name, @"\d+").Value, out ButtonNumber);
        Text = GetComponentInChildren<Text>().text;
        Text = Text.Split(' ').First();
    }

    public void OnClick()
    {
        _buttonsManager.SetActiveButton(this);
    }

    public void OnNextClick()
    {
        _buttonsManager.Next();
    }

    public void OnPreviusClick()
    {
        _buttonsManager.Previus();
    }

}
