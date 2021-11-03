using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Transform _cameraAngle;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) 
        {
            Camera.main.transform.SetPositionAndRotation(_cameraAngle.transform.position, _cameraAngle.transform.rotation);
        }
    }
}
