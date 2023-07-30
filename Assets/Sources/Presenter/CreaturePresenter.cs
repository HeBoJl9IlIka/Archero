using Archero.Model;
using UnityEngine;

public class CreaturePresenter : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] _scripts;
    [SerializeField] private Config.TypeEnemy _type;

    private float _timeNextAttack;

    public Config.TypeEnemy Type => _type;

    public Creature Model { get; private set; }
    public virtual bool IsMove { get; protected set; }

    private void Awake()
    {
        IsMove = true;
    }

    private void FixedUpdate()
    {
        Model.SetPosition(transform.position);

        if (IsMove == false)
        {
            if (Model.TrySetDirection())
                transform.rotation = Quaternion.LookRotation(Model.Direction);
        }

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
        Model.Disable();
    }

    public void Init(Creature creature)
    {
        Model = creature;
        Model.Enable();
        enabled = true;

        foreach (var script in _scripts)
            script.enabled = true;
    }

    private void OnDied()
    {
        gameObject.SetActive(false);
    }
}
