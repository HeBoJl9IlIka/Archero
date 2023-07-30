using Archero.Model;
using UnityEngine;

[RequireComponent(typeof(IMovable))]
public class EnemyPresenter : CreaturePresenter
{
    private IMovable[] _movables;

    private void Awake()
    {
        _movables = GetComponentsInChildren<IMovable>();
    }

    private void Update()
    {
        foreach (IMovable movable in _movables)
            IsMove = movable.IsMove;
    }
}
