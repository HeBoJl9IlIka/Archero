using Archero.Model;
using System.Collections.Generic;
using UnityEngine;

public class CreaturesRoot : MonoBehaviour
{
    [SerializeField] private CreaturePresenter[] _enemiesPresenter;
    [SerializeField] private CreaturePresenter _playerPresnter;

    private List<Creature> _creaturesModels = new List<Creature>();
    private Creature _player;

    private void Awake()
    {
        InitEnemies();
        InitPlayer();
    }

    private void InitEnemies()
    {
        foreach (CreaturePresenter enemyPresenter in _enemiesPresenter)
        {
            Health health = new Health(10000);
            Weapon weapon = new Weapon(50);
            TargetSelector targetSelector = new TargetSelector(_player);
            Creature enemy = new Creature(health, weapon, targetSelector, 5);
            enemyPresenter.Init(enemy);
            _creaturesModels.Add(enemy);
        }
    }

    private void InitPlayer()
    {
        Health health = new Health(100000);
        Weapon weapon = new Weapon(50);
        TargetSelector targetSelector = new TargetSelector(_creaturesModels.ToArray());
        _player = new Creature(health, weapon, targetSelector, 1);
        _playerPresnter.Init(_player);
    }
}
