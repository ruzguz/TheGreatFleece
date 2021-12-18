using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{

    [SerializeField] private AudioClip _audio;
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && _audio != null) 
        {
            AudioManager.Instance.PlayVoiceOver(_audio);
        }
    }
}
