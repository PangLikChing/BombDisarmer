using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public GameObject occupyingObject;
    public bool full;

    void Awake()
    {
        occupyingObject = null;
        full = false;
    }

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null && full == false)
        {
            //Snap into box
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition + transform.parent.gameObject.GetComponent<RectTransform>().anchoredPosition;

            //Box is occupied
            occupyingObject = eventData.pointerDrag.gameObject;
            occupyingObject.GetComponent<DragAndDrop>().itemSlot = gameObject;
            full = true;
        }
    }
}
