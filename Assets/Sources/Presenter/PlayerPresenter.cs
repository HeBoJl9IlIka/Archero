using StarterAssets;
using UnityEngine;

public class PlayerPresenter : CreaturePresenter
{
    [SerializeField] private StarterAssetsInputs _starterAssetsInputs;

    public override bool IsMove => _starterAssetsInputs.move != Vector2.zero;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyPresenter enemy))
            Model.TakeDamage(enemy._modelDamage);
    }
}
