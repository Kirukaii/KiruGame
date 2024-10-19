using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    CanvasGroup canvasGroup;
    public Transform lastParent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        lastParent = transform.parent;
        transform.SetParent(transform.parent.parent);
        print("start");

    }
    public void OnDrag(PointerEventData eventData)
    {
        print("onDrag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!transform.parent.name.StartsWith("ItemSlot"))
        {
            print("true");
            transform.SetParent(lastParent);
            transform.position = transform.parent.position;
        }
        print("End");
        canvasGroup.blocksRaycasts = true;
    }
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        lastParent = transform.parent;
    }

}
