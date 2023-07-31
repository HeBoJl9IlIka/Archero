using Archero.Model;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class CreaturesFactory : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private UICanvasControllerInput _controllerInput;
    [SerializeField] private CreaturePresenter[] _enemiesTemplates;
    [SerializeField] private CreaturePresenter _playerTemplate;
    [SerializeField] private Transform _minSpawnPosition;
    [SerializeField] private Transform _maxSpawnPosition;
    [SerializeField] private Transform _pointSpawnPlayer;

    public CreaturePresenter CreatePlayer(Creature creature)
    {
        CreaturePresenter creaturePresenter = Instantiate(_playerTemplate);
        creaturePresenter.transform.position = _pointSpawnPlayer.position;
        _camera.Follow = creaturePresenter.transform;
        _controllerInput.starterAssetsInputs = creaturePresenter.GetComponent<StarterAssetsInputs>();

        return creaturePresenter;
    }

    public CreaturePresenter CreateEnemy(CreatureCreator creatureCreator, Creature creature)
    {
        float randomAxisX = Random.Range(_minSpawnPosition.position.x, _maxSpawnPosition.position.x);
        float randomAxisZ = Random.Range(_minSpawnPosition.position.z, _maxSpawnPosition.position.z);
        Vector3 pointSpawn = new Vector3(randomAxisX, 0, randomAxisZ);
        CreaturePresenter creaturePresenter = null;

        foreach (var enemy in _enemiesTemplates)
        {
            if (enemy.Type == creatureCreator.Type)
            {
                creaturePresenter = Instantiate(enemy);
                creaturePresenter.transform.position = pointSpawn;
            }
        }

        return creaturePresenter;
    }
}
