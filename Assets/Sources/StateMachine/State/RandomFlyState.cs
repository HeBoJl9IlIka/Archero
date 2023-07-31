using Archero.Model;
using UnityEngine;

public class RandomFlyState : State, IMovable
{
    [SerializeField] private float _maxRadius;
    [SerializeField] private Transform _minFlyPosition;
    [SerializeField] private Transform _maxFlyPosition;

    private Vector3 _targetPosition;
    private bool _maxRight;
    private bool _minRight;

    public bool IsMove => transform.position != _targetPosition;

    private void Awake()
    {
        _minFlyPosition = GameObject.FindGameObjectWithTag("MinFly").transform;
        _maxFlyPosition = GameObject.FindGameObjectWithTag("MaxFly").transform;
    }

    private void Update()
    {
        NeedTransit = transform.position == _targetPosition;

        if (_maxRight && _minRight)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, 1 * Time.deltaTime);
    }

    private void OnEnable()
    {
        NeedTransit = false;
        _targetPosition = Vector3.zero;

        while (_maxRight == false && _minRight == false)
        {
            float randomAxisX = Random.Range(-_maxRadius, _maxRadius);
            float randomAxisZ = Random.Range(-_maxRadius, _maxRadius);
            _targetPosition = transform.position + new Vector3(randomAxisX, 3, randomAxisZ);

            if (_targetPosition.x <= _maxFlyPosition.position.x)
                _maxRight = _targetPosition.z <= _maxFlyPosition.position.z;

            if (_targetPosition.x >= _minFlyPosition.position.x)
                _minRight = _targetPosition.z >= _minFlyPosition.position.z;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WallPresenter wall))
            NeedTransit = true;

        if (other.TryGetComponent(out CreaturePresenter creaturePresenter))
            NeedTransit = true;
    }
}
