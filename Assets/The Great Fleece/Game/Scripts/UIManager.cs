using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance;

    public static UIManager Instance 
    {
        get 
        {
            if (_instance == null) 
            {
                Debug.LogError("UIManager is null");
            }
            return _instance;
        }
    }


    void Awake() 
    {
        if (_instance == null) 
        {
            _instance = this;
        }
    }

    public void Quit() 
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Restart()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
