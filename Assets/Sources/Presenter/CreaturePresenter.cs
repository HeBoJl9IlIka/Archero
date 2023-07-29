using Archero.Model;
using UnityEngine;

public class CreaturePresenter : MonoBehaviour
{
    private float _timeNextAttack;

    public Creature Model { get; private set; }
    public virtual bool IsMove { get; protected set; }

    private void Awake()
    {
        IsMove = false;
    }

    private void FixedUpdate()
    {
        Model.SetPosition(transform.position);

        if (IsMove == false)
        {
            if (Model.CanSetDirection())
                transform.rotation = Quaternion.LookRotation(Model.Direction);
        }
    }

    private void Update()
    {
        _timeNextAttack -= Time.deltaTime;

        if (_timeNextAttack >= 0)
            return;

        if (IsMove == false)
        {
            Model.CanAttack();
            _timeNextAttack = Model.SpeedAttack;
        }
    }

    private void OnEnable()
    {
        Model.Died += OnDied;
    }

    private void OnDisable()
    {
        Model.Died -= OnDied;
    }

    public void Init(Creature creature)
    {
        Model = creature;
        Model.Enable();
        enabled = true;
    }

    private void OnDied()
    {
        Model.Disable();
        gameObject.SetActive(false);
    }
}
