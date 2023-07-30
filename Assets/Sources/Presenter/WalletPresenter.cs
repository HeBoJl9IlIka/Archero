using Archero.Model;
using TMPro;
using UnityEngine;

public class WalletPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _value;

    private Wallet _model;

    private void OnEnable()
    {
        _model.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _model.Changed -= OnChanged;
    }

    public void Init(Wallet model)
    {
        _model = model;
        enabled = true;
    }

    private void OnChanged(int value)
    {
        _value.text = value.ToString();
    }
}
