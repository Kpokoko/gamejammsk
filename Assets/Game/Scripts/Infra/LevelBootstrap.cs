using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Infra
{
    public class LevelBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform trainRoot;
        [SerializeField] private float carriagesOffset;
        
        void Awake()
        {
            var levelData = G.LevelsDatabase.Levels[G.SaveManager.Data.CurrentLevelIndex];
            var playerSpawnPos = levelData.PlayerSpawnPoint;
            var player =
                Instantiate(GameResources.Prefabs.Player,
                    new Vector3(playerSpawnPos.x, playerSpawnPos.y, 0),
                    Quaternion.identity);
            player.GetComponent<CharacterController>().MoveDirection = levelData.MoveDirection;
            
            var train = LoadTrain(levelData);
            
            G.InitLevel(new LevelFlowController(), new CarriageManager(train));
            
            G.LevelFlowController.StartLevel();
        }

        List<Transform> LoadTrain(LevelSO levelData)
        {
            var trainsData = levelData.Carriages;
            
            // Это мб последний вагон прошлого уровня, туда зайти нельзя, но просто показываем
            var prev = Instantiate(trainsData[0].gameObject, trainRoot);
            var sr = prev.GetComponent<SpriteRenderer>();
            var width = sr.bounds.size.x;
            prev.transform.localPosition = new Vector3(
                -width - carriagesOffset,
                0,
                0);
            var right = prev.transform.Find("RightBorder").GetComponent<CarriageBorder>();
            right.Init(CarriageBorderType.Wall); // Блок доступа в предыдущий вагон
            
            var currentX = 0f;
            var carriages = new List<Transform>();
            
            for (var i = 1; i < trainsData.Count; ++i)
            {
                var carriage = Instantiate(trainsData[i].gameObject, trainRoot);
                carriage.transform.localPosition = new Vector3(currentX, 0, 0);
                sr = carriage.GetComponent<SpriteRenderer>();
                sr.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                currentX += sr.bounds.size.x + carriagesOffset;
                carriages.Add(carriage.transform);
                carriage.GetComponent<Carriage>().Number = i - 1;
                
                var left = carriage.transform.Find("LeftBorder").GetComponent<CarriageBorder>();
                right = carriage.transform.Find("RightBorder").GetComponent<CarriageBorder>();
                
                var isLast = i == trainsData.Count - 1;

                // #TODO Если последний - CarriageBorderType.WinTrigger и завершение уровня
                left.Init(isLast ? CarriageBorderType.Wall : CarriageBorderType.TransitionTrigger);
                right.Init(CarriageBorderType.TransitionTrigger);
            }
            
            return carriages;
        }

        void OnDestroy()
        {
            G.DisposeLevel();
        }
    }
}
