using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    private List<Image> _buttonsImage;
    private Sprite _spriteActive, _spriteUnactive;
    private Image _nextButton;
    private MainCanvas _mainCanvas;

    [SerializeField]
    private GameObject _cake;

    private Material _cakeMaterial;

    private void Awake()
    {
        _buttonsImage = new List<Image>();

        _spriteActive = Resources.Load<Sprite>("Sprites/SelectedButton");
        _spriteUnactive = Resources.Load<Sprite>("Sprites/Rectangle");
        _mainCanvas = transform.parent.parent.GetComponent<MainCanvas>();


        for (int i = 0; i < transform.childCount - 1; i++)
        {
            _buttonsImage.Add(transform.GetChild(i).GetComponent<Image>());
        }
        _nextButton = transform.GetChild(transform.childCount - 1).GetComponent<Image>();

        _cakeMaterial = _cake.GetComponent<MeshRenderer>().material;
    }

    public void SetActiveButton(int buttonIndex, string type)
    {
        switch (type)
        {
            case "Small":
                _cake.transform.localScale = new Vector3(15, 15, 15);
                break;
            case "Medium":
                _cake.transform.localScale = new Vector3(18, 18, 18);
                break;
            case "Large":
                _cake.transform.localScale = new Vector3(21, 21, 21);
                break;
            case "Choccolate":
                _cakeMaterial.color = new Color32(106, 51, 17, 255);
                break;
            case "Lemon":
                _cakeMaterial.color = new Color32(255, 212, 33, 255);
                break;
            case "Strawberry":
                _cakeMaterial.color = new Color32(233, 72, 60, 255);
                break;
            case "Cream":
                _cakeMaterial.color = new Color32(255, 255, 255, 255);
                break;
            case "Pistachio":
                _cakeMaterial.color = new Color32(101, 219, 85, 255);
                break;
            case "Coffee":
                _cakeMaterial.color = new Color32(99, 59, 41, 255);
                break;

        }
        for (int i = 0; i < _buttonsImage.Count; i++)
        {
            Image selectedButton = _buttonsImage[i];
            if (i == buttonIndex)
            {
                selectedButton.sprite = _spriteActive;
                selectedButton.color = new Color32(255, 236, 229, 100);
            }
            else
            {
                selectedButton.sprite = _spriteUnactive;
                selectedButton.color = new Color32(230, 230, 230, 255);
            }
        }

        _nextButton.color = new Color32(240, 99, 43, 255);
    }

    public void Next()
    {
        if(_nextButton.color == new Color32(240, 99, 43, 255))
        {
            _mainCanvas.FadeOut();
        }
    }
}
