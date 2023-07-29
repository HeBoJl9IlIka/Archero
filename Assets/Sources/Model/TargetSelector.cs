using System.Collections.Generic;
using UnityEngine;

namespace Archero.Model
{
    public class TargetSelector
    {
        private Creature _creature;
        private float _minDistance;

        public IReadOnlyCollection<Creature> Targets { get; private set; }

        public void SetTargets(Creature[] targets)
        {
            Targets = targets;
        }

        public void Init(Creature creature)
        {
            _creature = creature;
        }

        public Creature GetTarget()
        {
            Creature target = null;
            float distance;
            _minDistance = 100;

            foreach (Creature creature in Targets)
            {
                if (creature.IsDead == false)
                {
                    distance = Vector3.Distance(creature.Position, _creature.Position);

                    if (distance < _minDistance)
                    {
                        target = creature;
                        _minDistance = distance;
                    }
                }
            }

            return target;
        }
    }
}
