using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttons(int index)
    {
        PlayerPrefs.SetInt("currentLevel", index);
        SceneManager.LoadScene("Level " + index);
    }
}
