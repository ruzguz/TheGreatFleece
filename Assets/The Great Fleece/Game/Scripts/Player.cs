using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    // General Vars
    [SerializeField]
    private int _coins = 1; 

    // Movement variables
    private NavMeshAgent _agent;
    private Animator _animator;
    
    // References and prefabs 
    [SerializeField] private GameObject _coin;

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

        // Coin Distraction 
        if (Input.GetMouseButtonDown(1) && _coins > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) 
            {
                Instantiate(_coin,hit.point, Quaternion.identity);
                SendGuardToCoin(hit.point);
                _coins--;
            }
        }
    }

    void SendGuardToCoin(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard");
        foreach (GameObject guard in guards) 
        {
            guard.GetComponent<GuardAI>().MoveTo(coinPos);
        }
    }
}
