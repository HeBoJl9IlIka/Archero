using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _currentState;
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;
    public bool NeedTransit => _currentState.NeedTransit;

    private void OnEnable()
    {
        
    }
}