using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
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
        if (health <= 0)
        {
            Die();

        }
    }
    private void TakeDamage()
    {
        health -= 50;
        print(health);
    }
    private void Die()
    {
        gameObject.SetActive(false);
        StartCoroutine(waiter());
        gameObject.SetActive(true);
    }
    IEnumerator waiter()
    {
        print("death start");

        //Wait for 4 seconds
        yield return new WaitForSeconds(2);

        print("death end");

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage();
    }
    void OnTriggerStay2D(Collider2D collision)
    {

    }
    void OnTriggerExit2D(Collider2D collision)
    {
    }
}
