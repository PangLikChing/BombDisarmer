using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Canvas canvas;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;
    [SerializeField] public GameObject itemSlot;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        itemSlot = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    //Start drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemSlot != null)
        {
            itemSlot.gameObject.GetComponent<ItemSlot>().full = false;
        }
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    //End drag
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

    //Draging
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
