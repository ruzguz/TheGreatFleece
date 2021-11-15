using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    [SerializeField] private List<Transform> _wayPoints;
    [SerializeField] private int _currentTarget = 0;
    [SerializeField] private int _path = 1; // 1 = forward, -1 = reverse
    [SerializeField] private bool _targetReached = false;
    // Components
    private NavMeshAgent _agent;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator ==  null) 
        {
            Debug.LogError("GuardAI: _animator is NULL");
        }

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
            _animator.SetBool("Walk", true);

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
        _animator.SetBool("Walk", false);
        int randomTime = Random.Range(2, 6);
        _targetReached = true;
        yield return new WaitForSeconds(randomTime);
        _agent.SetDestination(_wayPoints[_currentTarget].position);
        _targetReached = false;
    }
}
