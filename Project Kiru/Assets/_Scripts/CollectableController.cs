using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    private ObjectManager objectManager;
    private Drops drop;
    internal static bool isPickable = false;
    internal static GameObject currentPickableObject;

    private void Start()
    {
        //For connection with other classes
        GameObject objectManager2 = GameObject.FindWithTag("ObjectManager");
        objectManager = objectManager2.GetComponent<ObjectManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        if (currentPickableObject)
        {
            currentPickableObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        currentPickableObject = gameObject;
        isPickable = true;
        objectManager.interactionPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = $"Press 'E' to collect {objectManager.dropsManager.GetComponent<Drops>().objectsDrops[GetComponent<SpriteRenderer>().sprite].name}";
        objectManager.interactionPanel.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (currentPickableObject)
        {
            currentPickableObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        objectManager.interactionPanel.SetActive(false);
        GetComponent<SpriteRenderer>().color = Color.white;
        currentPickableObject = null;
        isPickable = false;
    }
}
