using System.Collections.Generic;
using UnityEngine;

public class MovingState : IState
{
    private IStateSwitcher _stateSwitcher;
    private IMover _characterMover;
    private IState _previousState;

    private Queue<Vector3> _restPoints;
    private Queue<Vector3> _workingPoints;
    private CharacterConfig _characterConfig;

    private Transform _characterTransform;
    private Vector3 _currentDestination;    
    
    public MovingState(IStateSwitcher stateSwitcher, IMover characterMover, Transform characterTransform, CharacterConfig config, WayPoints wayPoints)
    {
        _characterTransform = characterTransform;
        _stateSwitcher = stateSwitcher;
        _characterMover = characterMover; 
        _characterConfig = config;

        FillWaypoints(wayPoints);
    }

    public void Enter()
    {
        Debug.Log(this.GetType());

        _previousState = _stateSwitcher.GetPreviousState();

        _currentDestination = _characterTransform.position;

        if (_previousState == null || _previousState is WorkingState)
        {
            _currentDestination = _restPoints.Dequeue();
            _restPoints.Enqueue(_currentDestination);
        }
        else        
        {
            _currentDestination = _workingPoints.Dequeue();
            _workingPoints.Enqueue(_currentDestination);
        }        

        _characterMover.OnObjectReachDestination += OnObjectReachDestination;
        _characterMover.MoveObject(_characterTransform, _currentDestination, _characterConfig.MovingSpeed);
     
    }

    public void Exit() => _characterMover.OnObjectReachDestination -= OnObjectReachDestination;

    public void Update() {}

    private void OnObjectReachDestination()
    {
        
        if (_previousState == null || _previousState is RestingState)
            _stateSwitcher.SwitchState<WorkingState>();

        else
            _stateSwitcher.SwitchState<RestingState>();
    }

    private void FillWaypoints(WayPoints wayPoints)
    {
        _restPoints = new Queue<Vector3>();
        _workingPoints = new Queue<Vector3>();

        foreach (Vector3 point in wayPoints.RestPoints)
            _restPoints.Enqueue(point);

        foreach (Vector3 point in wayPoints.WorkingPoints)
            _workingPoints.Enqueue(point);
    }
}
