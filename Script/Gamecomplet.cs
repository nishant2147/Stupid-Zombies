using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamecomplet : MonoBehaviour
{
    //public Text titleText;
    int currentLevel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void restart()
    {
        /*int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);*/

        int cLevel = PlayerPrefs.GetInt("currentLevel");
        SceneManager.LoadScene("Level " + (cLevel));
    }
    public void Next()
    {
        int cLevel = PlayerPrefs.GetInt("currentLevel");
        PlayerPrefs.SetInt("currentLevel", cLevel + 1);
        print("====>  " + cLevel);
        SceneManager.LoadScene("Level " + (cLevel + 1));
    }
}

