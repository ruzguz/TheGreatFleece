using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{


    [SerializeField]
    private GameObject _grabKeyCardCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GameManager.Instance.HasCard = true;
            _grabKeyCardCutscene.SetActive(true);
        }
    }
}
