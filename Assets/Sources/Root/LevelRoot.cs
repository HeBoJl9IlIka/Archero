using Archero.Model;
using UnityEngine;

[RequireComponent(typeof(CreaturesRoot))]
public class LevelRoot : MonoBehaviour
{
    [SerializeField] private BulletsFactory _bulletsFactory;
    [SerializeField] private PresentersFactory _presentersFactory;

    private CreaturesRoot _creaturesRoot;
    private Weapon[] _weapons;
    private Creature[] _enemies;
    private Wallet _wallet = new Wallet();

    private void Awake()
    {
        _creaturesRoot = GetComponent<CreaturesRoot>();
        _presentersFactory.CreateWalletPresenter(_wallet);
    }

    private void Start()
    {
        _weapons = _creaturesRoot.Weapons;
        _enemies = _creaturesRoot.Enemies;
        Subscribe();
    }

    private void OnDisable()
    {
        foreach (var weapon in _weapons)
            weapon.Shot -= OnShot;

        foreach (var enemy in _enemies)
            enemy.Died -= OnDied;
    }

    private void Subscribe()
    {
        foreach (var weapon in _weapons)
            weapon.Shot += OnShot;

        foreach (var enemy in _enemies)
            enemy.Died += OnDied;
    }

    private void OnShot(Creature creature, int damage)
    {
        BulletPresenter bulletPresenter = _bulletsFactory.CreateBullet(creature, new Bullet(damage));
    }

    private void OnDied()
    {
        _wallet.AddMoney(50);
    }
}
