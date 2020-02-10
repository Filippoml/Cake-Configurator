using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{


    public void OnMouseEnter()
    {
        transform.DOScale(1.2f, 0.2f);
    }

    public void OnMouseExit()
    {
        transform.DOScale(1.0f, 0.2f);
    }

}
