using StarterAssets;
using UnityEngine;

[RequireComponent(typeof(StarterAssetsInputs))]
public class PlayerPresenter : CreaturePresenter
{
    private StarterAssetsInputs _starterAssetsInputs;

    public override bool IsMove => _starterAssetsInputs.move != Vector2.zero;

    private void Awake()
    {
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
}
