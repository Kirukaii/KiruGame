using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    [SerializeField]
    internal GameObject boundSlot;
    public bool isSlotUsed = false;

    private void Update()
    {

        if (transform.childCount > 0 )
        {
            boundSlot.transform.GetChild(0).gameObject.SetActive(true);
            boundSlot.transform.GetChild(0).GetComponent<Image>().sprite = transform.GetChild(0).GetComponent<Image>().sprite;
            boundSlot.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = transform.GetChild(0).GetComponent<Item>().stackCount.ToString();

            transform.GetChild(0).GetComponent<Image>().raycastPadding = new Vector4(-64, -64, -64, -64);

            isSlotUsed = true;
        }

        if (transform.childCount == 0 && isSlotUsed)
        {
            boundSlot.transform.GetChild(0).gameObject.SetActive(false);
            isSlotUsed =false;

        }
        

    }
}
