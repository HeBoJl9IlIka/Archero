using Archero.Model;
using UnityEngine;

public class PresentersFactory : MonoBehaviour
{
    [SerializeField] private WalletPresenter _walletTemplate;
    [SerializeField] private TimeCounterPresenter _timeCounterTemplate;

    public WalletPresenter CreateWallet(Wallet model)
    {
        WalletPresenter walletPresenter = Instantiate(_walletTemplate);
        walletPresenter.Init(model);

        return walletPresenter;
    }

    public TimeCounterPresenter CreateTimeCounter()
    {
        return Instantiate(_timeCounterTemplate);
    }
}
