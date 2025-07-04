using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
[RequireComponent(typeof(Enemy))]

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    
    private State _currentState;
    private Player _target;  
    public State  Current => _currentState;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Reset(_firstState);
    }
    private void Update()
    {
        if (_currentState == null)
            return;
        var nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }
    private void Reset(State startState)
    {
        _currentState= startState;
        if (_currentState !=null)
        {
            _currentState.Enter(_target);
        }
    }
    private void Transit (State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();
        _currentState = nextState;
        if (_currentState != null)
            _currentState.Enter(_target);

    }

}
