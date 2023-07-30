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
    [SerializeField] private Transform _minSpawnVector;
    [SerializeField] private Transform _maxSpawnVector;
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
        float randomAxisX = Random.Range(_minSpawnVector.position.x, _maxSpawnVector.position.x);
        float randomAxisZ = Random.Range(_minSpawnVector.position.z, _maxSpawnVector.position.z);
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
