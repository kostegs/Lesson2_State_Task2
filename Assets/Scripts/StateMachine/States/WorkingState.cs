using UnityEngine;

public class WorkingState : IState
{
    private IStateSwitcher _stateSwitcher;
    private IWorker _character;
    private CharacterConfig _characterConfig;
    private float _timer;

    public WorkingState(IStateSwitcher stateSwitcher, IWorker character, CharacterConfig characterConfig)
    {
        _stateSwitcher = stateSwitcher;
        _character = character;
        _characterConfig = characterConfig;
    }

    public void Enter()
    {
        Debug.Log(GetType());
        _timer = 0;
        _character.StartWork();
    }

    public void Exit()
    {
        _character.StopWork();
    }

    public void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _characterConfig.TimeForRest)
            _stateSwitcher.SwitchState<MovingState>();
    }
}
