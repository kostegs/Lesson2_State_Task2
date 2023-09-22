using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Character : MonoBehaviour, IWorker, IRester
{
    [SerializeField] private Mover _mover;

    public Mover Mover => _mover;

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
