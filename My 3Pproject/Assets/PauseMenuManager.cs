using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pausescreen;
    public CinemachineBrain cinemachineBrain;
    public static bool onPause;
    float previousTimeScale;
    // Start is called before the first frame update
    void Start()
    {
        previousTimeScale = Time.timeScale;
        onPause = false;
        pausescreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (!onPause)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }
    void Pause()
    {
        onPause = true;
        pausescreen.SetActive(true);
        cinemachineBrain.enabled = !onPause;
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }
    void UnPause()
    {
        onPause = false;
        pausescreen.SetActive(false);
        cinemachineBrain.enabled = !onPause;
        Time.timeScale = previousTimeScale;
    }
    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
