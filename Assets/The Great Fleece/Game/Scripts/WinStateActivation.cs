using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _winCutscene;

    private void OnTriggerEnter(Collider other) 
    {
        if (GameManager.Instance.HasCard == true && other.tag == "Player") 
        {
            _winCutscene.SetActive(true);
        }
    }
}
