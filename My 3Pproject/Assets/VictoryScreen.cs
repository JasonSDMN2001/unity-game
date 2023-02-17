using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryscreen;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnPause();

        }
    }
    void UnPause()
    {
        victoryscreen.SetActive(false);
    }
}
