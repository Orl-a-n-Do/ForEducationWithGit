using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private AgentCharacter _prefab;
    [SerializeField] private float _radius;
    [SerializeField] private int _count;

    private List<Controller> _controllers = new();

    public void Spawn(Transform target)
    {   
        
        NavMeshQueryFilter queryFilter = new NavMeshQueryFilter();
        queryFilter.agentTypeID = 0;
        queryFilter.areaMask = 1;

        for (int i = 0; i < _count; i++)
        {
            int attempts = 0;
            const int maxAttempts = 100;
            Vector3 positionAroundTarget = Vector3.zero;
            NavMeshHit spawnPoint = new NavMeshHit();
            bool foundPosition = false;

            do
            {
                Vector2 randomPositionInCircle = Random.insideUnitCircle * _radius;
                Vector3 offset = new Vector3(randomPositionInCircle.x, 0, randomPositionInCircle.y);

                positionAroundTarget = target.position + offset;
                attempts++;

                if (attempts >= maxAttempts)
                {
                    Debug.LogWarning($"Не удалось найти позицию для врага {i} после {maxAttempts} попыток. Пропускаем.");
                    break;
                }

                foundPosition = NavMesh.SamplePosition(positionAroundTarget, out spawnPoint, 1f, queryFilter);

            } while (!foundPosition);

            // Создаем врага только если нашли валидную позицию
           if (foundPosition)
            {
                AgentCharacter instance = Instantiate(_prefab, spawnPoint.position, Quaternion.identity, null);
                instance.Initialize();

                Controller controller = new AgentCharacterAgroController(instance, target, 30, 2, 1);

                controller.Enable();
                _controllers.Add(controller);
            }
            
            // ЕСЛИ НУЖНО ОТКЛЮЧИТЬ СПАВН ВРАГОВ - ЗАКОММЕНТИРУЙТЕ ВЕСЬ БЛОК ВЫШЕ
            // И РАСКОММЕНТИРУЙТЕ СТРОКУ НИЖЕ:
            // Debug.Log("Спавн врагов отключен");


        }

    }

    private void Update()
    {
        foreach (Controller controller in _controllers)
            controller.Update(Time.deltaTime);
    }

}
