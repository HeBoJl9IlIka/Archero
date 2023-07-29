using Archero.Model;
using UnityEngine;

public class CreaturePresenter : MonoBehaviour
{
    private Creature _model;

    private void Update()
    {
        _model.SetPosition(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BulletPresenter bullet))
            _model.TakeDamage(bullet._modelTypeDamage, bullet._modelDamage);

        if (other.TryGetComponent(out EnemyPresenter enemy))
            _model.TakeDamage(enemy._modelTypeDamage, enemy._modelDamage);
    }

    public void Init(Creature creature)
    {
        _model = creature;
        enabled = true;
    }
}
