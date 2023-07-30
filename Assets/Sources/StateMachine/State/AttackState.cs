using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float _duration;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;

        NeedTransit = _time >= _duration;
    }

    private void OnEnable()
    {
        NeedTransit = false;
        _time = 0;
    }
}
