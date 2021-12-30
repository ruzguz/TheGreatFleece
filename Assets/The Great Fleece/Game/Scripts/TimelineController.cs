using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{

    [SerializeField]
    PlayableDirector playableDirector;
    [SerializeField]
    private float _skipTime;

    public void Skip() 
    {
        playableDirector.time = _skipTime;
    }

    public void LockCursor(bool lockValue)
    {
        if (lockValue == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        } else 
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Update() 
    {
        // Skip cutscene
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            Skip();
        }
    }
}
