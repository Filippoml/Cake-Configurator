using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image _barFill;

    [SerializeField]
    private List<Image> _backgroundPointsImages;

    private int _pointReached;

    public void FillPoint(bool next)
    {
        Image point = null;
        if (next)
        {
            point = _backgroundPointsImages[_pointReached - 1];

            DOTween.To(() => point.fillAmount, x => point.fillAmount = x, 1, 0.2f);
            Text text = point.transform.parent.GetChild(0).GetComponent<Text>();
            text.color = point.color;
        }
        else
        {
            _pointReached--;
            point = _backgroundPointsImages[_pointReached];

            DOTween.To(() => point.fillAmount, x => point.fillAmount = x, 0, 0.2f).OnComplete(() => { FillToPoint(next); });
            Text text = point.transform.parent.GetChild(0).GetComponent<Text>();
            text.color = new Color32(135, 135, 135, 255);
        }
    }

    public void FillToPoint(bool next)
    {
        if (next)
        {
            _pointReached++;

            DOTween.To(() => _barFill.fillAmount, x => _barFill.fillAmount = x, 0.33f * _pointReached, 1).OnComplete(() => { FillPoint(next); });
        }
        else
        {
            DOTween.To(() => _barFill.fillAmount, x => _barFill.fillAmount = x, 0.33f * _pointReached, 1);
        }
    }

    public void SetFilledPoint(int pointNum)
    {
        for(int i = _pointReached; i <= pointNum; i++)
        {
            Image point = _backgroundPointsImages[i - 1];
            point.fillAmount = 1;
            Text text = point.transform.parent.GetChild(0).GetComponent<Text>();
            text.color = point.color;
        }
        _barFill.fillAmount = 0.33f * pointNum;
    }
}
