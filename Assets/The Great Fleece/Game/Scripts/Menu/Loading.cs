using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;
    [SerializeField]
    private Image _progressBarOverlay;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync() 
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Main");
        //asyncOperation.allowSceneActivation = false;

        while(!asyncOperation.isDone) 
        {
            _progressBar.fillAmount = asyncOperation.progress;
            _progressBarOverlay.fillAmount = asyncOperation.progress;

            yield return new WaitForEndOfFrame();
        }
    }
}
