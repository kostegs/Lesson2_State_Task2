using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private Character _character;

    private void Awake() => _character.Initialize();
}
