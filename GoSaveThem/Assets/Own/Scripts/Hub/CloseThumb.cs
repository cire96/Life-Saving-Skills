using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseThumb : MonoBehaviour, IPointerClickHandler
{
    public GameObject Thumb, ThumbWhite, ThumbBlur;
    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {
        Thumb.SetActive(false);
        ThumbWhite.SetActive(false);
        ThumbBlur.SetActive(false);
    }
}
