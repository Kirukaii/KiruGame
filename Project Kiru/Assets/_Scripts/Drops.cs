using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using static UnityEditor.Progress;

public class Drops : MonoBehaviour
{
    // Dictionary<Sprite, string> objectsDrops = new();

    internal Dictionary<Sprite, Sprite> objectsDrops = new();
    
    private ObjectManager objectManager;

    // Start is called before the first frame update
    void Start()
    {
        //Logs if scripted is working
        Debug.Log("Drops Script Loaded!");

        //For connection with other classes
        GameObject objectManager2 = GameObject.FindWithTag("ObjectManager");
        objectManager = objectManager2.GetComponent<ObjectManager>();

        for (int i = 0; i < objectManager.collectables.Length; i++)
        {
            objectsDrops.Add(objectManager.collectables[i].GetComponent<SpriteRenderer>().sprite, objectManager.drops[i]);
        }
    }
}
