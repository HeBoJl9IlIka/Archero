using Archero.Model;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelectorPresenter : MonoBehaviour
{
    private TargetSelector _model;
    private float _minDistance;

    private void OnEnable()
    {
        _model.SelectingTarget += OnSelectingTarget;
    }

    private void OnDisable()
    {
        _model.SelectingTarget -= OnSelectingTarget;
    }

    public void Init(TargetSelector model)
    {
        _model = model;
        enabled = true;
    }

    private void OnSelectingTarget(IReadOnlyCollection<Creature> creatures)
    {
        Creature target = null;

        foreach (Creature creature in creatures)
        {
            float distance = Vector3.Distance(creature.Position, transform.position);

            if (_minDistance == 0)
            {
                target = creature;
                _minDistance = distance;
            }

            if (distance < _minDistance)
            {
                target = creature;
                _minDistance = distance;
            }
        }

        _model.SetTarget(target);
    }
}
