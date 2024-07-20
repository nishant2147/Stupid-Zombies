
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTouch : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 lastVelocity;
    int maxhits = 10;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        maxhits--;

        if (maxhits <= 0)
        {
            Destroy(gameObject,maxhits);
            GameObject[] bulletget = GameObject.FindGameObjectsWithTag("bulletdestroy");
            GameObject[] BulletCounts = GameObject.FindGameObjectsWithTag("BulletCount");
            GameObject[] Zombies = GameObject.FindGameObjectsWithTag("Kill");
            /*if (bulletget.Length > 0)
            {
                print("count dest--->" + bulletget.Length);
            }
            //print("bulletget = " + bulletget.Length + "   |   BulletCounts = " + BulletCounts.Length + "   |   Zombies = " + Zombies.Length*/

            if (Zombies.Length == 0)
            {
                //print("gameComplete===>" + Zombies.Length);
                Guncont.gamecomplet = true;
            }
            else if (bulletget.Length == 1 && BulletCounts.Length == 0)
            {
                //print("gameover===>" + bulletget.Length);
                Guncont.gameover = true;
            }
        }
        else
        {
            //print("Touch --->");
            var inDirection = lastVelocity.normalized;
            var inNormal = collision.contacts[0].normal;
            var reflect = Vector2.Reflect(inDirection, inNormal);
            var bulletangle = Mathf.Atan2(reflect.y, reflect.x) * Mathf.Rad2Deg;
            rb.rotation = bulletangle + 90f;

            var lastSpeed = lastVelocity.magnitude;
            rb.velocity = reflect * lastSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Kill")
        {
            Destroy(collision.gameObject);
        }
    }
}