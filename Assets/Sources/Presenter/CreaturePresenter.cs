using Archero.Model;
using UnityEngine;

public class CreaturePresenter : MonoBehaviour
{
    protected Creature _model;
    private float _timeNextAttack;

    public virtual bool IsMove { get; protected set; }

    private void Awake()
    {
        IsMove = true;
    }

    private void FixedUpdate()
    {
        _model.SetPosition(transform.position);

        if (IsMove == false)
        {
            if (_model.CanSetDirection())
                transform.rotation = Quaternion.LookRotation(_model.Direction);
        }
    }

    private void Update()
    {
        _timeNextAttack -= Time.deltaTime;

        if (_timeNextAttack >= 0)
            return;

        if (IsMove == false)
        {
            _model.CanAttack();
            _timeNextAttack = _model.SpeedAttack;
        }
    }

    private void OnEnable()
    {
        _model.Died += OnDied;
    }

    private void OnDisable()
    {
        _model.Died -= OnDied;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BulletPresenter bullet))
            _model.TakeDamage(bullet._modelDamage);

        if (other.TryGetComponent(out EnemyPresenter enemy))
            _model.TakeDamage(enemy._modelDamage);
    }

    public void Init(Creature creature)
    {
        _model = creature;
        _model.Enable();
        enabled = true;
    }

    private void OnDied()
    {
        _model.Disable();
        gameObject.SetActive(false);
    }
}
