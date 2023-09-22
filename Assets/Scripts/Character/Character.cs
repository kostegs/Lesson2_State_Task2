using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Character : MonoBehaviour, IWorker, IRester
{
    [SerializeField] private IMover _mover;
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private WayPoints _waypoints;

    public IMover Mover => _mover;   
    public CharacterConfig CharacterConfig => _config; 
    public WayPoints WayPoints => _waypoints;
    
    private CharacterStateMachine _stateMachine;
    private bool _isInitialized;

    private void Update()
    {
        if (_isInitialized == false)
            return;

        _stateMachine.Update();
    }

    public void Initialize()
    {
        _mover = GetComponent<Mover>();

        _stateMachine = new CharacterStateMachine(this);

        _isInitialized = true;
    }

    public void StartWork() => Debug.Log("I'm working now");

    public void StopWork() => Debug.Log("I've finished work");

    public void StartRest() => Debug.Log("I'm resting now");

    public void StopRest() => Debug.Log("I've finished my rest");

}
