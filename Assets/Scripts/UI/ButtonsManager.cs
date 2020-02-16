using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    private List<Image> _buttonsImage;
    private Sprite _spriteActive, _spriteUnactive;
    private Image _previusButton,_nextButton;
    private MainCanvas _mainCanvas;

    [SerializeField]
    private GameObject _cake;

    private int _cakeSize;

    [SerializeField]
    private bool _canSelectMoreThanOne;

    private Material _cakeMaterial;

    private void Awake()
    {
        _cakeSize = 1;
        _buttonsImage = new List<Image>();

        _spriteActive = Resources.Load<Sprite>("Sprites/SelectedButton");
        _spriteUnactive = Resources.Load<Sprite>("Sprites/Rectangle");
        _mainCanvas = transform.parent.parent.GetComponent<MainCanvas>();


        for (int i = 0; i < transform.childCount - 2; i++)
        {
            _buttonsImage.Add(transform.GetChild(i).GetComponent<Image>());
        }
        _previusButton = transform.GetChild(transform.childCount - 2).GetComponent<Image>();
        _nextButton = transform.GetChild(transform.childCount - 1).GetComponent<Image>();

        _cakeMaterial = _cake.GetComponent<MeshRenderer>().material;
    }

    public void SetActiveButton(CustomButton button)
    {
        switch (button.Text)
        {
            case "Small":
                _cake.transform.localScale = new Vector3(15, 15, 15);
                if (!button.IsActive)
                {
                    _mainCanvas.UpdatePriceAdd(-1.5f * (_cakeSize - 1));
                    _cakeSize = 1;
                }
                break;
            case "Medium":
                if (!button.IsActive)
                {
                    if (_cakeSize < 2)
                    {
                        _mainCanvas.UpdatePriceAdd(1.5f);
                    }
                    else
                    {
                        _mainCanvas.UpdatePriceAdd(-1.5f);
                    }
                    _cakeSize = 2;
                }
                _cake.transform.localScale = new Vector3(18, 18, 18);
                break;
            case "Large":
                if (!button.IsActive)
                {
                    _mainCanvas.UpdatePriceAdd(1.5f * (3 - _cakeSize));
                    _cakeSize = 3;
                }
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
            case "Strawberries":
                if (button.IsActive)
                {
                    _mainCanvas.RemoveTopping(0);
                    _mainCanvas.UpdatePriceAdd(-2.5f);
                }
                else
                {
                    _mainCanvas.AddTopping(0);
                    _mainCanvas.UpdatePriceAdd(2.5f);

                }
                break;
            case "Berries":
                if(button.IsActive)
                {
                    _mainCanvas.RemoveTopping(1);
                    _mainCanvas.UpdatePriceAdd(-2.5f);

                }
                else
                {
                    _mainCanvas.AddTopping(1);
                    _mainCanvas.UpdatePriceAdd(2.5f);

                }
                break;
        }

        for (int i = 0; i < _buttonsImage.Count; i++)
        {
            Image selectedButton = _buttonsImage[i];
            if (i == button.ButtonNumber)
            {
                if(_canSelectMoreThanOne && selectedButton.color == new Color32(255, 236, 229, 255))
                {
                    selectedButton.sprite = _spriteUnactive;
                    selectedButton.gameObject.GetComponent<CustomButton>().IsActive = false;
                    selectedButton.color = new Color32(230, 230, 230, 255);
                }
                else
                {
                    selectedButton.sprite = _spriteActive;
                    selectedButton.gameObject.GetComponent<CustomButton>().IsActive = true;
                    selectedButton.color = new Color32(255, 236, 229, 255);
                }
            }
            else if (!_canSelectMoreThanOne && _buttonsImage[i].gameObject != _previusButton)
            {
                selectedButton.sprite = _spriteUnactive;
                selectedButton.gameObject.GetComponent<CustomButton>().IsActive = false;
                selectedButton.color = new Color32(230, 230, 230, 255);
            }
        }

        _nextButton.color = new Color32(240, 99, 43, 255);
    }

    public void Next()
    {
        if(_nextButton.color == new Color32(240, 99, 43, 255))
        {
            _mainCanvas.FadeOut(true);
        }
    }

    public void Previus()
    {
        _mainCanvas.FadeOut(false);
    }
}
