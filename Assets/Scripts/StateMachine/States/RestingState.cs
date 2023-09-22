using UnityEngine;

public class RestingState : IState
{
    private IStateSwitcher _stateSwitcher;
    private IRester _character;
    private CharacterConfig _characterConfig;
    private float _timer;

    public RestingState(IStateSwitcher stateSwitcher, IRester character, CharacterConfig characterConfig)
    {
        _stateSwitcher = stateSwitcher;
        _character = character;
        _characterConfig = characterConfig;
    }

    public void Enter()
    {
        Debug.Log(GetType());
        _timer = 0;
        _character.StartRest();
    }

    public void Exit()
    {
        _character.StopRest(); 
    }

    public void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _characterConfig.TimeForRest)
            _stateSwitcher.SwitchState<MovingState>();        
        
    }
}
