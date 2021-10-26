using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firsState;


    private Player _target;
    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Resett(_firsState);
            
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var netxState = _currentState.GetNextState();
        if (netxState != null)
            Transit(netxState);

    }

    private void Resett(State startState) // для сброса стэйтов, вернуться к первому состоянию
    {
        _currentState = startState;

        if (_currentState != null) //если есть какойто стейт, его уже ктото указал
            _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
}
