using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingState : IState
{
    private IStateSwitcher _stateSwitcher;
    private Character _character;
    private Mover _characterMover;

    public MovingState(IStateSwitcher stateSwitcher, Character character)
    {
        _stateSwitcher = stateSwitcher;
        _character = character;
        _characterMover = character.Mover;
    }

    public void Enter()
    {
        Debug.Log(this.GetType());
    }

    public void Exit() {}

    public void Update()
    {
        IState previousState = _stateSwitcher.GetPreviousState();

        if (previousState == null || previousState is RestingState)         
            _stateSwitcher.SwitchState<WorkingState>();
        
        else 
            _stateSwitcher.SwitchState<RestingState>();
    }
}
