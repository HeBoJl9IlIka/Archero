using Archero.Model;
using TMPro;
using UnityEngine;

public class TimeCounterPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;

    private LevelRoot _levelRoot;
    private float _time = Config.DelayStart;

    private void Update()
    {
        if (_time <= 0)
        {
            _levelRoot.StartGame();
            enabled = false;
        }

        _counter.text = _time.ToString("#");
        _time -= Time.deltaTime;
    }

    public void Init(LevelRoot levelRoot)
    {
        _levelRoot = levelRoot;
        enabled = true;
    }
}
