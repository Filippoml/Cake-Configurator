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

    private void Awake()
    {
        _pointReached = 1;
    }


    private void fillPoint()
    {
        Image point = _backgroundPointsImages[_pointReached - 1];
        DOTween.To(() => point.fillAmount, x => point.fillAmount = x, 1, 0.2f);

        Text text = point.transform.parent.GetChild(0).GetComponent<Text>();
        text.color = point.color;

        _pointReached++;

    }

    public void FillToNextPoint()
    {
        DOTween.To(() => _barFill.fillAmount, x => _barFill.fillAmount = x, 0.33f * _pointReached, 1).OnComplete(fillPoint);
    }
}
