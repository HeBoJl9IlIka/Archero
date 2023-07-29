using System;
using System.Collections.Generic;

namespace Archero.Model
{
    public class TargetSelector
    {
        private Creature _creature;

        public IReadOnlyCollection<Creature> Targets { get; private set; }

        public event Action<IReadOnlyCollection<Creature>> SelectingTarget;

        public TargetSelector(Creature[] targets)
        {
            Targets = targets;
        }

        public void Init(Creature creature)
        {
            _creature = creature;
        }

        public void SetTargets(Creature[] targets)
        {
            Targets = targets;
        }

        public void SelectTarget()
        {
            SelectingTarget?.Invoke(Targets);
        }

        public void SetTarget(Creature target)
        {
            _creature.SetTraget(target);
        }
    }
}
