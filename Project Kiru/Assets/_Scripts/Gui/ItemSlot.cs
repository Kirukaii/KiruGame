using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private void Update()
    {
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            print("called");
            transform.GetChild(0).position = eventData.pointerDrag.GetComponent<DragItem>().lastParent.position;
            transform.GetChild(0).SetParent(eventData.pointerDrag.GetComponent<DragItem>().lastParent);
            eventData.pointerDrag.GetComponent<Image>().raycastPadding = new Vector4(-24, -24, -24, -24);
        }
        eventData.pointerDrag.transform.SetParent(transform);
        eventData.pointerDrag.transform.position = transform.position;

    }
}
