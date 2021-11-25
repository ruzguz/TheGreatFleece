using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _startCamera;


    void Start() 
    {
        transform.position = _startCamera.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player);
    }
}
