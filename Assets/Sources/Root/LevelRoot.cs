using Archero.Model;
using UnityEngine;

[RequireComponent(typeof(CreaturesRoot))]
public class LevelRoot : MonoBehaviour
{
    [SerializeField] private BulletsFactory _bulletsFactory;

    private CreaturesRoot _creaturesRoot;
    private Weapon[] _weapons;

    private void Awake()
    {
        _creaturesRoot = GetComponent<CreaturesRoot>();
    }

    private void Start()
    {
        _weapons = _creaturesRoot.Weapons;
        Subscribe();
    }

    private void OnDisable()
    {
        foreach (var weapon in _weapons)
            weapon.Shot -= OnShot;
    }

    private void Subscribe()
    {
        foreach (var weapon in _weapons)
            weapon.Shot += OnShot;
    }

    private void OnShot(Creature creature, int damage)
    {
        BulletPresenter bulletPresenter = _bulletsFactory.CreateBullet(creature, new Bullet(damage));
    }
}
