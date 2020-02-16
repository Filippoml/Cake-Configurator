using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{

    private int _selectedSectionIndex;
    private float _duration = 0.5f;

    private float _price = 20;

    [SerializeField]
    private CustomProgressBar _progressBar;

    [SerializeField]
    private Text _priceText;

    [SerializeField]
    private Transform _toppingParent;

    private void Awake()
    {
        _selectedSectionIndex = 2;

        if (_priceText != null)
        {
            _priceText.text = "Price: €" + _price.ToString("N2");
        }
    }

    private void showPanel(int panel)
    {
        panel += 2;
        foreach (Image image in transform.GetChild(2).GetComponentsInChildren<Image>())
        {
            image.DOFade(0, 0);
        }

        int lenght = transform.GetChild(2).GetComponentsInChildren<Text>().Length;
        for (int i = 0; i < lenght; i++)
        {
            Text text = transform.GetChild(2).GetComponentsInChildren<Text>()[i];

            if (i == lenght - 1)
            {
                text.DOFade(0, 0);
            }
            else
            {
                text.DOFade(0, 0);
            }
        }
        transform.GetChild(2).gameObject.SetActive(false);


        transform.GetChild(panel).gameObject.SetActive(true);
        foreach (Image image in transform.GetChild(panel).GetComponentsInChildren<Image>())
        {
            image.DOFade(1, 0.1f);
        }

        foreach (Text text in transform.GetChild(panel).GetComponentsInChildren<Text>())
        {
            text.DOFade(1, 0.1f);
        }
    }

    private void Start()
    {
        for (int i = _selectedSectionIndex + 1; i < transform.childCount; i++)
        {
            foreach (Image image in transform.GetChild(i).GetComponentsInChildren<Image>())
            {
                image.DOFade(0, 0);
            }

            foreach (Text text in transform.GetChild(i).GetComponentsInChildren<Text>())
            {
                text.DOFade(0, 0);

            }
        }
    }

    public void FadeOut(bool next)
    {
        if (next)
        {
            _progressBar.FillToPoint(next);
        }
        else
        {
            _progressBar.FillPoint(next);
        }

        foreach (Image image in transform.GetChild(_selectedSectionIndex).GetComponentsInChildren<Image>())
        {
            image.DOFade(0, _duration);
        }

        int lenght = transform.GetChild(_selectedSectionIndex).GetComponentsInChildren<Text>().Length;
        for (int i = 0; i < lenght; i++)
        {
            Text text = transform.GetChild(_selectedSectionIndex).GetComponentsInChildren<Text>()[i];

            if (i == lenght - 1)
            {
                text.DOFade(0, _duration).OnComplete(() => { FadeIn(next);  });
            }

            else
            {
                text.DOFade(0, _duration);
            }
        }
        
    }

    private void FadeIn(bool next)
    {
        transform.GetChild(_selectedSectionIndex).gameObject.SetActive(false);
        if (next)
        {
            _selectedSectionIndex++;
        }
        else
        {
            _selectedSectionIndex--;
        }
        transform.GetChild(_selectedSectionIndex).gameObject.SetActive(true);
        foreach (Image image in transform.GetChild(_selectedSectionIndex).GetComponentsInChildren<Image>())
        {
            image.DOFade(1, _duration + 0.3f);
        }

        foreach (Text text in transform.GetChild(_selectedSectionIndex).GetComponentsInChildren<Text>())
        {
            text.DOFade(1, _duration + 0.3f);
        }
    }

    public void AddTopping(int numberTopping)
    {
        _toppingParent.GetChild(numberTopping).gameObject.SetActive(true);
    }

    public void RemoveTopping(int numberTopping)
    {
        _toppingParent.GetChild(numberTopping).gameObject.SetActive(false);
    }

    public void UpdatePrice(float price)
    {
        _price = price;
        _priceText.text = "Price: €" + _price.ToString("N2");
    }


    public void UpdatePriceAdd(float price)
    {
        _price += price;
        _priceText.text = "Price: €" + _price.ToString("N2");
    }

}
