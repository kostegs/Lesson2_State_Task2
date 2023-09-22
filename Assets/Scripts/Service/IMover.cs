using System;
using UnityEngine;

public interface IMover
{
    event Action OnObjectReachDestination;

    void MoveObject(Transform objectTransform, Vector3 destination, float speed);
}
