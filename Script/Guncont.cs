using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Guncont : MonoBehaviour
{
    public GameObject aim;
    public Transform bulletspawn;
    public GameObject bulletPrefab;
    float bulletforce = 900f;

    public static bool gameover = false;
    public GameObject gameOverPanel;

    public static bool gamecomplet = false;
    public GameObject gamecompletpanel;

    public static bool canFire = true;


    // Start is called before the first frame update
    void Start()
    {
        gamecomplet = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(gameover)
        {
            gameOverPanel.SetActive(true);
            return;
        }
        if(gamecomplet && canFire)
        {
            gamecompletpanel.SetActive(true);
            canFire = false;
            return;
        }

        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Kill");
        if (zombies.Length == 0)
        {
            gamecompletpanel.SetActive(true);
            return;
        }
       

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //print("mouse Position --->  " + mousePos);
        aim.transform.position = new Vector3(
            mousePos.x,
            mousePos.y,
            aim.transform.position.z
            );

        var offset = mousePos - transform.position;
        var GunAngle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, GunAngle);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject[] bulletCounts = GameObject.FindGameObjectsWithTag("BulletCount");
            if (bulletCounts.Length > 0)
            {
                var b = bulletCounts[bulletCounts.Length - 1];
                b.transform.parent = null;
                Destroy(b);
                bulletshoot(GunAngle);
            }
        }
    }
    private void bulletshoot(float GunAngle)
    {
        var bullet = Instantiate(bulletPrefab, bulletspawn.position, Quaternion.Euler(0,0, GunAngle + 90));
        var rb = bullet.GetComponent<Rigidbody2D>();

        Vector3 Myposition = Camera.main.WorldToScreenPoint(bulletspawn.position);
        var bulletdirection = Input.mousePosition - Myposition;
        bulletdirection = bulletdirection.normalized * bulletforce;

        //print("direction  ---->  " + bulletdirection);
        rb.AddForce(bulletdirection);
    }

}
