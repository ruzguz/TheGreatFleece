using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{

    private Animator _animator;
    [SerializeField] 
    private GameObject _gameOverCutscene;
    [SerializeField]
    private MeshRenderer _coneRenderer;

    private void Start() 
    {
        _animator =  GetComponent<Animator>();
        if (_animator == null) 
        {
            Debug.LogError("Animator is NULL");
        }

        _coneRenderer = GetComponentsInChildren<MeshRenderer>()[1];
        if (_coneRenderer == null) 
        {
            Debug.LogError("Mesh Renderer is NULL");
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(ActiveCutscene());
        }
    }

    IEnumerator ActiveCutscene()
    {
        Color color = new Color(0.6f,0.1f,0.1f,0.3f);
        _coneRenderer.material.SetColor("_TintColor", color);
        _animator.enabled = false;
        yield return new WaitForSeconds(1.0f);
        _gameOverCutscene.SetActive(true);
    }
}
