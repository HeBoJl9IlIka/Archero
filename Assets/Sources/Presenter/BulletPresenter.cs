using Archero.Model;
using UnityEngine;

public class BulletPresenter : MonoBehaviour
{
    private Creature _shooter;
    private Bullet _model;

    private void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CreaturePresenter target))
        {
            if (target.Model != _shooter)
            {
                _model.ApplyDamage(target.Model);
                gameObject.SetActive(false);
            }
        }
    }

    public void Init(Creature creature, Bullet model)
    {
        _model = model;
        _shooter = creature;
        enabled = true;
        gameObject.SetActive(true);
    }
}
