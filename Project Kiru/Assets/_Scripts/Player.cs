using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    //Attribute
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    //private int health = 100;
    private float moveSpeed = 1.5f;

    internal bool pickedUp = false;

    internal List<Quest> questsList = new List<Quest>();

    //For connection with other classes
    private ObjectManager objectManager;

    //Initialisation
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    //Start
    void Start()
    {
        GetComponentInChildren<Animator>().StopPlayback();
        Debug.Log("Player Script Loaded!");

        //For connection with other classes
        objectManager = GameObject.FindWithTag("ObjectManager").GetComponent<ObjectManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponentInChildren<Animator>().Play("Arrow");
        }

        //Movement Function
        Move();
        if (CollectableController.isPickable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                objectManager.inventory.GetComponent<Inventory>().AddItem(CollectableController.currentPickableObject);
                CollectableController.currentPickableObject.SetActive(false);
            }
        }
        //Oppening the Inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!objectManager.inventory.activeSelf)
            {
                objectManager.inventory.SetActive(true);
            }
            else
            {
                objectManager.inventory.SetActive(false);
            }
        }
        //shows the quests in the list
        if (questsList.Count > 0)
        {
            foreach (Quest quest in questsList)
            {
                objectManager.questText.text = $"{quest.name}";
                foreach (var r in quest.Requirements)
                {
                    if (objectManager.inventory.transform.Find(r.req.name))
                    {
                        objectManager.questText.text += $"\n-{r.req.name}: {r.Amount - objectManager.inventory.transform.Find(r.req.name).GetComponent<Item>().stackCount}";
                        
                    }
                    else
                    {
                        objectManager.questText.text += $"\n-{r.req.name}: {r.Amount}";
                    }

                }
            }

        }
    }
    void Move()
    {

        // Pobierz wejście od gracza
        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;
        float verticalInput = Input.GetAxis("Vertical") * moveSpeed;

        // Oblicz wektor ruchu na podstawie wejścia
        Vector2 movement = new(horizontalInput, verticalInput);

        // Zaktualizuj pozycję postaci
        rb.velocity = movement * moveSpeed;

        //Flipt the sprite
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //flip();
            sprite.flipX = false;

            //Debug.Log("1");
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //flip();
            sprite.flipX = true;

        }
    }



    //public void TakeDamage(int damageAmount)
    //{
    //    health -= damageAmount;
    //    if (health <= 0)
    //    {
    //        Die();
    //    }
    //}

    //private void Die()
    //{
    //    // Logika śmierci gracza
    //}


}
