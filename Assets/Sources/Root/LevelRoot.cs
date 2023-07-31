using Archero.Model;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CreaturesFactory))]
public class LevelRoot : MonoBehaviour
{
    [SerializeField] private BulletsFactory _bulletsFactory;
    [SerializeField] private PresentersFactory _presentersFactory;
    [SerializeField] private CreatureCreator[] _creatureCreators;

    private TimeCounterPresenter _timeCounterPresenter;
    private CreaturesFactory _creaturesFactory;
    private List<Weapon> _weapons = new List<Weapon>();
    private List<Creature> _enemies = new List<Creature>();
    private Creature _player;
    private List<CreaturePresenter> _enemiesPresnter = new List<CreaturePresenter>();
    private CreaturePresenter _playerPresenter;
    private Wallet _wallet = new Wallet();

    private void Awake()
    {
        _creaturesFactory = GetComponent<CreaturesFactory>();
        CreateEnemies();
        CreatePlayer();
        SetTargetsForCreatures();

        _presentersFactory.CreateWallet(_wallet);
        _timeCounterPresenter = _presentersFactory.CreateTimeCounter();
    }

    private void Start()
    {
        _timeCounterPresenter.Init(this);
    }

    private void OnEnable()
    {
        foreach (var weapon in _weapons)
            weapon.Shot += OnShot;

        foreach (var enemy in _enemies)
            enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        foreach (var weapon in _weapons)
            weapon.Shot -= OnShot;

        foreach (var enemy in _enemies)
            enemy.Died -= OnDied;
    }

    public void StartGame()
    {
        InitCreatures();
        _timeCounterPresenter.gameObject.SetActive(false);
    }

    private void OnShot(Creature creature, int damage)
    {
        BulletPresenter bulletPresenter = _bulletsFactory.CreateBullet(creature, new Bullet(damage));
    }

    private void OnDied()
    {
        _wallet.AddMoney(50);
    }

    private void CreatePlayer()
    {
        Health health = new Health(300);
        Weapon weapon = new Weapon(50);
        TargetSelector targetSelector = new TargetSelector();
        _player = new Creature(health, weapon, targetSelector, 1, 20);
        _playerPresenter = _creaturesFactory.CreatePlayer(_player);
        _weapons.Add(weapon);
    }

    private void CreateEnemies()
    {
        foreach (var creator in _creatureCreators)
        {
            Health health = new Health(100);
            Weapon weapon = new Weapon(50);
            TargetSelector targetSelector = new TargetSelector();
            Creature enemy = new Creature(health, weapon, targetSelector, 2, 20);
            _enemiesPresnter.Add(_creaturesFactory.CreateEnemy(creator, enemy));
            _weapons.Add(weapon);
            _enemies.Add(enemy);
        }
    }

    private void SetTargetsForCreatures()
    {
        Creature[] creatures = { _player };

        foreach (Creature creature in _enemies)
            creature.SetTargets(creatures);

        _player.SetTargets(_enemies.ToArray());
    }

    private void InitCreatures()
    {
        for (int i = 0; i < _enemiesPresnter.Count; i++)
            _enemiesPresnter[i].Init(_enemies[i]);

        _playerPresenter.Init(_player);
    }
}
