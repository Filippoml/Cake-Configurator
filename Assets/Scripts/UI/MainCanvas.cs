using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private GameObject _strawberriesResource, _berriesResource;

    private void Awake()
    {
        _selectedSectionIndex = 2;
        _priceText.text = "Price: €" + _price.ToString("N2");

        _strawberriesResource = Resources.Load<GameObject>("Prefabs/Strawberries");
        _berriesResource = Resources.Load<GameObject>("Prefabs/Berries");
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

    public void FadeOut()
    {
        _progressBar.FillToNextPoint();

        foreach (Image image in transform.GetChild(_selectedSectionIndex).GetComponentsInChildren<Image>())
        {
            image.DOFade(0, _duration);
        }

        int lenght = transform.GetChild(_selectedSectionIndex).GetComponentsInChildren<Text>().Length;
        for (int i = 0; i < lenght; i++)
        {
            Text text = transform.GetChild(_selectedSectionIndex).GetComponentsInChildren<Text>()[i];

            if(i == lenght - 1)
            {
                text.DOFade(0, _duration).OnComplete(FadeIn);
            }
            else
            {
                text.DOFade(0, _duration);
            }
        }
    }

    private void FadeIn()
    {
        _selectedSectionIndex++;
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
        Debug.Log("test");
        switch (numberTopping)
        {
            case 1:
                Instantiate(_strawberriesResource, _toppingParent);
                break;
            case 2:
                Instantiate(_berriesResource, _toppingParent);
                break;
            default:
                Debug.LogError("error!");
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            FadeOut();
        }
    }

    public void UpdatePrice(float price)
    {
        _price = price;
        _priceText.text = "Price: €" + _price.ToString("N2");
    }
}
