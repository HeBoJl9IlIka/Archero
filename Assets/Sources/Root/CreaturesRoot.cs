using Archero.Model;
using System.Collections.Generic;
using UnityEngine;

public class CreaturesRoot : MonoBehaviour
{
    [SerializeField] private CreaturePresenter[] _enemiesPresenter;
    [SerializeField] private CreaturePresenter _playerPresnter;

    private List<Creature> _creatures = new List<Creature>();
    private List<Weapon> _weapons = new List<Weapon>();
    private Creature _player;

    public Weapon[] Weapons => _weapons.ToArray(); 

    private void Awake()
    {
        InitPlayer();
        InitEnemies();

        Creature[] creatures = { _player };

        foreach (Creature creature in _creatures)
            creature.SetTargets(creatures);

        _player.SetTargets(_creatures.ToArray());
    }

    private void InitEnemies()
    {

        foreach (CreaturePresenter enemyPresenter in _enemiesPresenter)
        {
            Health health = new Health(100);
            Weapon weapon = new Weapon(50);
            TargetSelector targetSelector = new TargetSelector();
            Creature enemy = new Creature(health, weapon, targetSelector, 2);
            enemyPresenter.Init(enemy);
            _creatures.Add(enemy);
            _weapons.Add(weapon);
        }
    }

    private void InitPlayer()
    {
        Health health = new Health(300);
        Weapon weapon = new Weapon(50);
        TargetSelector targetSelector = new TargetSelector();
        _player = new Creature(health, weapon, targetSelector, 1);
        _playerPresnter.Init(_player);
        _weapons.Add(weapon);
    }
}
