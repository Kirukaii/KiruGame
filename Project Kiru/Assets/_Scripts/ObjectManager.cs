using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    //public static ObjectManager instance;
    public GameObject dialogBox;
    public TMP_Text dialogText;
    public GameObject questList;
    public TMP_Text questText;
    public GameObject questDoneText;
    public GameObject inventory;
    public GameObject interactionPanel;


    public Button Quickslot1;
    public Button Quickslot2;
    public Button Quickslot3;
    public Button Quickslot4;

    public GameObject itemPrefab;
    public GameObject itemInfo;
    public GameObject dropsManager;
     
    public GameObject[] collectables;
    public Sprite[] drops;
    private void Start()
    {
        Debug.Log("ObjectManager script Loaded");

        dialogBox.SetActive(false);
        questDoneText.SetActive(false);
        inventory.SetActive(false);
        questList.SetActive(true);
        interactionPanel.SetActive(false);
        itemInfo.SetActive(false);
        //GameObject test1 = new();
        //test1.name = ".1";
        //GameObject go3 = new("go3", typeof(Rigidbody), typeof(BoxCollider));
        //GameObject t = new("go3", typeof(Rigidbody), typeof(BoxCollider));
        //GameObject goa3 = new("go3", typeof(Rigidbody), typeof(BoxCollider));

    }
    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
