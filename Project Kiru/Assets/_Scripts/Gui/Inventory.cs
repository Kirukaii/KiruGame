using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    //For connection with other classes
    private Player player;
    private ObjectManager objectManager;
    private Drops drop;

    internal Dictionary<GameObject,int> items = new Dictionary<GameObject,int>();
    public List<GameObject> itemSlots;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inventory Script Loaded!");

        //For connection with other classes
        GameObject objectManager2 = GameObject.FindWithTag("ObjectManager");
        objectManager = objectManager2.GetComponent<ObjectManager>();

        GameObject player2 = GameObject.FindWithTag("Player");
        player = player2.GetComponent<Player>();

        drop = objectManager2.GetComponent<Drops>();

        foreach (Transform item in transform.Find("Slots"))
        {
            itemSlots.Add(item.gameObject);
        }
    }
    internal void AddItem(GameObject item)
    {
        print("Adding an Item");
        foreach (var i2 in itemSlots)
        {
            if (i2.transform.childCount > 0)
            {
                if (i2.transform.GetChild(0).name == item.name)
                {
                    print("Item already exist");

                    items[i2.transform.GetChild(0).gameObject] += 1;
                    return;
                }
            }
        }
        print("New Item");

        foreach (var i in itemSlots)
        {
            if (i.transform.childCount == 0)
            {
                GameObject itemObject = Instantiate(objectManager.itemPrefab);
                itemObject.name = objectManager.dropsManager.GetComponent<Drops>().objectsDrops[item.GetComponent<SpriteRenderer>().sprite].name;
                itemObject.transform.SetParent(i.transform);
                itemObject.transform.position = i.transform.position;
                itemObject.GetComponent<Image>().sprite = objectManager.dropsManager.GetComponent<Drops>().objectsDrops[item.GetComponent<SpriteRenderer>().sprite]; 
                items.Add(itemObject, 1);
                return;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

        // run if something was added to the inventory arrays
        // displays the content of the arrays as a string, so you can see the items in the inventory
        //if (loopBreaker)
        //{
        //    var itemsAndAmount = items.Zip(itemsAmount, (i, a) => new { Item = i, Amount = a });

        //    foreach (var x in itemsAndAmount)
        //    {
        //        if (x.Item != null)
        //        {
        //            if (!inventoryitemsText.text.Contains(drop.objectsDrops[x.Item.GetComponent<SpriteRenderer>().sprite])) 
        //            {
        //                inventoryitemsText.text += $"{drop.objectsDrops[x.Item.GetComponent<SpriteRenderer>().sprite]} {x.Amount}\n";
        //            }
        //            else
        //            {
        //                inventoryitemsText.text = $"{drop.objectsDrops[x.Item.GetComponent<SpriteRenderer>().sprite]} {x.Amount}\n";
        //            }
        //        }
        //    }
            
        //    loopBreaker = false;
        //}

        // if the function pickUp was called in the Player script
        // Adds the Item which was picked up, in to the array, and increases the Amount array with same Index at 1
        //if (player.pickedUp == true)
        //{

        //    player.pickedUp = false;
        //    loopBreaker = false;

        //    for (int i = 0; i < items.Length && loopBreaker == false; i++)
        //    {

        //        if (items[i] == null)
        //        {
        //            items[i] = player.actualCollision.gameObject;
        //            itemsAmount[i]++;
        //            loopBreaker = true;
        //        }
        //        else
        //        {   
        //            if (items[i].name == player.actualCollision.gameObject.name)
        //            {
        //                itemsAmount[i]++;
        //                loopBreaker = true;
        //            }
        //        }

        //    }

        //}
    }
}
