using Archero.Model;
using UnityEngine;

public class PresentersFactory : MonoBehaviour
{
    [SerializeField] private WalletPresenter _walletTemplate;

    public WalletPresenter CreateWalletPresenter(Wallet model)
    {
        WalletPresenter walletPresenter = Instantiate(_walletTemplate);
        walletPresenter.Init(model);

        return walletPresenter;
    }
}
