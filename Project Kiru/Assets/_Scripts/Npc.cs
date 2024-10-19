
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class Npc : MonoBehaviour
{
    internal bool entered = false;
    private bool questTaken;
    private ObjectManager objectManager;
    Queue<Quest> questsToGive = new Queue<Quest>();
    List<GameObject> questsDone = new List<GameObject>();

    void Start()
    {
        Debug.Log("NPC script Loaded");
        questTaken = false;

        GameObject objectManager2 = GameObject.FindWithTag("ObjectManager");
        objectManager = objectManager2.GetComponent<ObjectManager>();

        var tempQuestList = gameObject.GetComponentsInChildren<Quest>();
        
        foreach (var quest in tempQuestList)
        {
            questsToGive.Enqueue(quest);
        }
    }
    void Update()
    {
        ShowDialog();
    }
    private void ShowDialog()
    {
        if (!entered)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Turn OFF and ON
            if (objectManager.dialogBox.activeSelf)
            {
                objectManager.dialogBox.SetActive(false);
            }
            else
            {
                objectManager.dialogBox.SetActive(true);
            }
            GiveQuest();
        }
    }
    private void GiveQuest()
    {
        if (questTaken)
        {
            
            foreach (var r in questsToGive.Peek().Requirements)
            {
                if (r.Amount == objectManager.inventory.transform.Find(r.req.name).GetComponent<Item>().stackCount)
                {
                    print("Req fullfilled");
                    objectManager.dialogText.text = "Dziękuję, oto twoja nagroda!";
                    
                    Destroy(objectManager.inventory.transform.Find(r.req.name).gameObject);

                    return;
                }
                else
                {
                }

            }
            objectManager.dialogText.text = "Już otrzymałeś zadanie! Bierz się do roboty!";
            print("Quest Taken");
            return;

        }
        print("Giving Quest");
        //temporary variable to save all the children of the Object Inventory


        objectManager.dialogText.text = questsToGive.Peek().dialog;

        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().questsList.Add(questsToGive.Peek());

        questTaken = true;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        entered = true;
    }
    void OnTriggerStay2D(Collider2D collision)
    {

        objectManager.interactionPanel.SetActive(true);
        objectManager.interactionPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = $"Press 'E' to talk";

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        entered = false;
        objectManager.dialogBox.SetActive(false);
        objectManager.interactionPanel.SetActive(false);

    }
}
