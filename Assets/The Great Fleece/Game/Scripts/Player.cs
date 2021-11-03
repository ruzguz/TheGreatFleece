using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    // Movement variables
    private NavMeshAgent _agent;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) 
            {
                _agent.SetDestination(hit.point);
            }

        }
        Debug.Log(_agent.remainingDistance + " - " + _agent.stoppingDistance);
        if (_agent.remainingDistance <= _agent.stoppingDistance) 
        {
            _animator.SetBool("Walk", false);
        } else 
        {
            _animator.SetBool("Walk", true);
        }
    }
}
