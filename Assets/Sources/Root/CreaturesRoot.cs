using Archero.Model;
using System.Collections.Generic;
using UnityEngine;

public class CreaturesRoot : MonoBehaviour
{
    [SerializeField] private CreaturePresenter[] _enemiesPresenter;
    [SerializeField] private CreaturePresenter _playerPresnter;

    private List<Creature> _enemies = new List<Creature>();
    private List<Weapon> _weapons = new List<Weapon>();
    private Creature _player;

    public Weapon[] Weapons => _weapons.ToArray(); 
    public Creature[] Enemies => _enemies.ToArray();

    private void Awake()
    {
        InitPlayer();
        InitEnemies();

        Creature[] creatures = { _player };

        foreach (Creature creature in _enemies)
            creature.SetTargets(creatures);

        _player.SetTargets(_enemies.ToArray());
    }

    private void InitEnemies()
    {

        foreach (CreaturePresenter enemyPresenter in _enemiesPresenter)
        {
            Health health = new Health(100);
            Weapon weapon = new Weapon(50);
            TargetSelector targetSelector = new TargetSelector();
            Creature enemy = new Creature(health, weapon, targetSelector, 2, 20);
            enemyPresenter.Init(enemy);
            _enemies.Add(enemy);
            _weapons.Add(weapon);
        }
    }

    private void InitPlayer()
    {
        Health health = new Health(300);
        Weapon weapon = new Weapon(50);
        TargetSelector targetSelector = new TargetSelector();
        _player = new Creature(health, weapon, targetSelector, 1, 20);
        _playerPresnter.Init(_player);
        _weapons.Add(weapon);
    }
}
