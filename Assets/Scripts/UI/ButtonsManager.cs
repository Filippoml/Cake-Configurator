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

    }

    public void SetActiveButton(int buttonIndex)
    {
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
