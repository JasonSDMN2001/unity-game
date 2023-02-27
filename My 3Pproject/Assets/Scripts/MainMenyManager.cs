using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenyManager : MonoBehaviour
{
    [SerializeField] GameObject blocker;
    // Start is called before the first frame update
    void Start()
    {
        blocker.SetActive(false);   
    }
    public void StartApp()
    {
        blocker.SetActive(true);    
        SceneManager.LoadSceneAsync("DemoScene");
    }
    public void Quit()
    {
        Application.Quit();
        blocker.SetActive(true);

    }
}
