using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (health == 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = collision.transform.position;
    }
    void OnTriggerStay2D(Collider2D collision)
    {



    }
    void OnTriggerExit2D(Collider2D collision)
    {
    }
}
