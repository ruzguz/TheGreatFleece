using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame() 
    {
        SceneManager.LoadScene("Load");
    }

    public void Quit()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
