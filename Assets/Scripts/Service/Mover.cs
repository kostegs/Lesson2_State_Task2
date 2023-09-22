using System;
using UnityEngine;

public class Mover : MonoBehaviour, IMover
{
    public const float DistanceToAchieveDestination = 0.1f;

    public event Action OnObjectReachDestination;

    private Transform _objectTransform;
    private Vector3 _destination;
    private float _speed;
    private bool _isMoving;

    private void Update()
    {
        if (_isMoving == false)
            return;

        Vector3 direction = (_destination - _objectTransform.position).normalized;
        _objectTransform.Translate(direction * _speed * Time.deltaTime);

        if (IsObjectAchievedDestination(_objectTransform, _destination))
        {
            _isMoving = false;
            OnObjectReachDestination?.Invoke();
        }
    }

    public void MoveObject(Transform objectTransform, Vector3 destination, float speed)
    {
        _objectTransform = objectTransform; 
        _destination = destination;        
        _speed = speed;
        _isMoving = true;
    }
    
    private bool IsObjectAchievedDestination(Transform objectTransform, Vector3 destination)
        => (objectTransform.position - destination).sqrMagnitude <= DistanceToAchieveDestination;
    
}
