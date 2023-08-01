using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;
    private State _curretnState;

    public State State => _curretnState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_firstState);
    }

    private void Update()
    {
        if (_curretnState == null)
            return;

        var nextState = _curretnState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _curretnState = startState;

        if (_curretnState != null)
            _curretnState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_curretnState != null)
            _curretnState.Exit();

        _curretnState = nextState;

        if (_curretnState != null)
            _curretnState.Enter(_target);
    }
}
