using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinding : MonoBehaviour
{
    private ObjectManager objectManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //For connection with other classes
        GameObject objectManager2 = GameObject.FindWithTag("ObjectManager");
        objectManager = objectManager2.GetComponent<ObjectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { 
            objectManager.Quickslot1.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            objectManager.Quickslot2.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            objectManager.Quickslot3.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            objectManager.Quickslot4.onClick.Invoke();
        }
    }
    public void ButtonFunktion()
    {
        print("Button Clicked.");
    }
}
