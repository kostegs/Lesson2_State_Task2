using UnityEngine;

public class RestingState : IState
{
    private IStateSwitcher _stateSwitcher;
    private IRester _character;

    public RestingState(IStateSwitcher stateSwitcher, IRester character)
    {
        _stateSwitcher = stateSwitcher;
        _character = character;
    }

    public void Enter()
    {
        Debug.Log(GetType());
        _character.StartRest();
    }

    public void Exit()
    {
        _character.StopRest(); 
    }

    public void Update()
    {
        _stateSwitcher.SwitchState<MovingState>();
    }
}
