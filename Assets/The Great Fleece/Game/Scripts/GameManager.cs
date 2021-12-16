using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance 
    {
        get 
        {
            if (_instance == null) 
            {
                Debug.LogError("Game Manager is null");
            }
            return _instance;
        }
    }

    [field: SerializeField]
    public bool HasCard { get; set; }

    void Awake() {
        if (_instance == null) 
        {
            _instance = this;
        }
    }
}
