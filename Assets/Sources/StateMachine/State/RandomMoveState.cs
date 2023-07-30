using Archero.Model;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomMoveState : State, IMovable
{
    [SerializeField] private float _maxRadius;

    private NavMeshAgent _agent;
    private Vector3 _targetPosition;

    public bool IsMove => _agent.hasPath;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        NeedTransit = _agent.hasPath;
    }

    private void OnEnable()
    {
        NeedTransit = false;
        _agent.ResetPath();
        float randomAxisX = Random.Range(-_maxRadius, _maxRadius);
        float randomAxisZ = Random.Range(-_maxRadius, _maxRadius);
        _targetPosition = transform.position + new Vector3(randomAxisX, 0, randomAxisZ);

        _agent.destination = _targetPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WallPresenter wall))
            NeedTransit = true;

        if (other.TryGetComponent(out CreaturePresenter creaturePresenter))
            NeedTransit = true;

        if (NeedTransit)
            _agent.ResetPath();
    }
}
