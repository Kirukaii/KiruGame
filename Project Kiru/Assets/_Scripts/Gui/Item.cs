using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isStackable = true;
    public bool isUseable = false;

    public UnityEvent itemUse;
    public int stackCount = 0;
    public int maxStackSize = 100;
    private ObjectManager objectManager;

    // Start is called before the first frame update
    void Start()
    {

        //For connection with other classes
        GameObject objectManager2 = GameObject.FindWithTag("ObjectManager");
        objectManager = objectManager2.GetComponent<ObjectManager>();

        if (!isStackable)
            transform.GetChild(0).gameObject.SetActive(false);
        print("ITEM START");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            itemUse.Invoke();
        //Makes Error
        //stackCount = objectManager.inventory.GetComponent<Inventory>().items[gameObject];
        //transform.GetChild(0).GetComponent<TMP_Text>().text = stackCount.ToString();
        if (stackCount > maxStackSize)
        {
            transform.GetChild(0).GetComponent<TMP_Text>().text = maxStackSize.ToString();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        objectManager.itemInfo.SetActive(true);
        objectManager.itemInfo.transform.position = new Vector2(eventData.position.x+100, eventData.position.y+100);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objectManager.itemInfo.SetActive(true);
    }
}
