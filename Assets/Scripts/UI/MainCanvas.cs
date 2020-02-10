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

    private void Awake()
    {
        _selectedSectionIndex = 1;
    }

    private void Start()
    {
        for(int i = 2; i < transform.childCount; i++)
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            FadeOut();

        }
    }
}
