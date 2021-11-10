using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    [SerializeField] private List<Transform> _wayPoints;
    [SerializeField] private int _currentTarget = 0;
    [SerializeField] private int _path = 1;
    [SerializeField] private bool _targetReached = false;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_wayPoints.Count > 0 && _wayPoints[0] != null) 
        {
            _agent.SetDestination(_wayPoints[_currentTarget].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_wayPoints.Count > 0 && _wayPoints[0] != null && _targetReached == false) 
        {
            float distance = Vector3.Distance(transform.position, _wayPoints[_currentTarget].position);
            
            if (distance < 1.0f) 
            {
                // Set waypoint path
                if (_currentTarget <= 0) 
                {
                    _path = 1;
                } else if (_currentTarget >= _wayPoints.Count -1) 
                {
                    _path = -1;
                }

                // Check for the first and the last waypoitn to stop the guard for 5 seconds
                if (_currentTarget == 0 || _currentTarget == _wayPoints.Count - 1) 
                {
                    _currentTarget += _path;
                    StartCoroutine(WaitBeforeMove());
                } else 
                {
                    _currentTarget += _path;
                    _agent.SetDestination(_wayPoints[_currentTarget].position);
                }
            }
        }
    }

    IEnumerator WaitBeforeMove()
    {
        _targetReached = true;
        yield return new WaitForSeconds(5.0f);
        _agent.SetDestination(_wayPoints[_currentTarget].position);
        _targetReached = false;
    }
}
