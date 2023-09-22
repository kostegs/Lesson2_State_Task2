using UnityEngine;

public class WorkingState : IState
{
    private IStateSwitcher _stateSwitcher;
    private IWorker _character;

    public WorkingState(IStateSwitcher stateSwitcher, IWorker character)
    {
        _stateSwitcher = stateSwitcher;
        _character = character;
    }

    public void Enter()
    {
        Debug.Log(GetType());
        _character.StartWork();
    }

    public void Exit()
    {
        _character.StopWork();
    }

    public void Update()
    {
        _stateSwitcher.SwitchState<MovingState>();
    }
}
