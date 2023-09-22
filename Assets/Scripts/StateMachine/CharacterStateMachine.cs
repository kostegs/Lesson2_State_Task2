using System.Collections.Generic;
using System.Linq;

public class CharacterStateMachine : IStateSwitcher
{

    private IState _currentState;
    private List<IState> _states;
    private Stack<IState> _previousStates;
    private Character _character;

    public CharacterStateMachine(Character character)
    {
        _character = character;

        _states = new List<IState>()
        {
            new RestingState(this, _character),
            new MovingState(this, _character),
            new WorkingState(this, _character),
        };

        _previousStates = new Stack<IState>();
        _currentState = _states[0];
        SwitchState<MovingState>();
    }

    public IState GetPreviousState()
    {
        return _previousStates.Pop();
    }

    public void Update() => _currentState.Update();

    public void SwitchState<T>() where T : IState
    {
        IState stateToSwitch = _states.FirstOrDefault(state => state is  T);

        _previousStates.Push(_currentState);

        _currentState.Exit();
        _currentState = stateToSwitch;
        _currentState.Enter();
    }
}
