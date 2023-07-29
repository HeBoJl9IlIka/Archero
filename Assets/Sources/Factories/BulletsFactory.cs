using Archero.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletsFactory : MonoBehaviour
{
    [SerializeField] private BulletPresenter _templatesBullets;
    [SerializeField] private Transform _container;

    private int _amountBullets = 50;
    private List<BulletPresenter> _bullets = new List<BulletPresenter>();

    private void Awake()
    {
        for (int i = 0; i < _amountBullets; i++)
        {
            BulletPresenter bulletPresenter = Instantiate(_templatesBullets);
            _bullets.Add(bulletPresenter);
            bulletPresenter.transform.parent = _container;
            bulletPresenter.gameObject.SetActive(false);
        }
    }

    public BulletPresenter CreateBullet(Creature creature, Bullet model)
    {
        BulletPresenter bulletPresenter = _bullets.FirstOrDefault(bulletPresenter => bulletPresenter.gameObject.activeSelf == false);

        if (bulletPresenter != null)
        {
            bulletPresenter.transform.position = creature.Position;
            bulletPresenter.transform.rotation = Quaternion.LookRotation(creature.Direction);
            bulletPresenter.Init(creature, model);
        }

        return bulletPresenter;
    }
}