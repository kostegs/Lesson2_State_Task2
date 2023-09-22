using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _restPoints;
    [SerializeField] private List<Transform> _workingpoints;

    public IEnumerable<Vector3> RestPoints => _restPoints.Select(point => point.position);
    public IEnumerable<Vector3> WorkingPoints => _workingpoints.Select(point => point.position);

}
