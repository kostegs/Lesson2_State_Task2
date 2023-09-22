using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/Character config")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField, Range(0,10)] private float _movingSpeed;
    [Header("Time for work and rest in seconds")]
    [SerializeField] private float _timeForWork;
    [SerializeField] private float _timeForRest;

    public float MovingSpeed => _movingSpeed;   
    public float TimeForWork => _timeForWork;
    public float TimeForRest => _timeForRest;
}
