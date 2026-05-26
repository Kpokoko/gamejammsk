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
            
            var currentX = 0f;
            var carriages = new List<Transform>();
            
            for (var i = 1; i < trainsData.Count; ++i)
            {
                var carriage = Instantiate(trainsData[i].gameObject, trainRoot);
                carriage.transform.localPosition = new Vector3(currentX, 0, 0);
                sr = carriage.GetComponent<SpriteRenderer>();
                currentX += sr.bounds.size.x + carriagesOffset;
                carriages.Add(carriage.transform);
                carriage.GetComponent<Carriage>().Number = i;
                
                var left = carriage.transform.Find("LeftBorder").GetComponent<CarriageBorder>();
                var right = carriage.transform.Find("RightBorder").GetComponent<CarriageBorder>();
                
                var isFirst = i == 1;
                var isLast = i == trainsData.Count - 1;

                left.Init(isFirst ? CarriageBorderType.Wall : CarriageBorderType.Trigger);
                right.Init(isLast ? CarriageBorderType.Wall : CarriageBorderType.Trigger);
            }
            
            return carriages;
        }

        void OnDestroy()
        {
            G.DisposeLevel();
        }
    }
}
