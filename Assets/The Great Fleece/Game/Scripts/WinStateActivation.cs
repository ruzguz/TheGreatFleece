using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _winCutscene;

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Enter");
        if (GameManager.Instance.HasCard == true && other.tag == "Player") 
        {
            Debug.Log("Win teh game");
            _winCutscene.SetActive(true);
        }
    }
}
