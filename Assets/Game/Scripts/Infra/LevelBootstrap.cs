using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.DialogueModule;
using Game.Scripts.Managers;
using Game.Scripts.Triggers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Game.Scripts.Infra
{
    public class LevelBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform trainRoot;
        [SerializeField] private float carriagesOffset;
        private float _currentTrainX = 0f;
        
        void Awake()
        {
            var dialogueSystem = new DialogueSystem();

            var (player, train) = LoadLevel(GetLevelSO());
            G.InitLevel(new LevelFlowController(dialogueSystem), new CarriageManager(train), dialogueSystem);
            
            G.LevelFlowController.OnLevelComplete += ReloadLevel;
            G.LevelFlowController.SetCharacter(player);
            G.LevelFlowController.StartLevel();
        }

        LevelSO GetLevelSO() => G.LevelsDatabase.Levels[G.SaveManager.Data.CurrentLevelIndex];
        
        public void ReloadLevel()
        {
            Debug.Log("Уходим в подзагрузку/перезагрузку");
            ExtendTrain();
            // G.CarriageManager.ClearTrain(G.CarriageManager.CarriageCount - 1);
        }

        (CharacterController, List<Transform>) LoadLevel(LevelSO levelData)
        {
            var player = LoadPlayer();
            var train = LoadTrain(levelData);
            
            return (player, train);
        }

        CharacterController LoadPlayer()
        {
            var levelData = GetLevelSO();
            var playerSpawnPos = levelData.PlayerSpawnPoint;
            var player =
                Instantiate(GameResources.Prefabs.Player,
                    new Vector3(playerSpawnPos.x, playerSpawnPos.y, 0),
                    Quaternion.identity);
            player.GetComponent<CharacterController>().MoveDirection = levelData.MoveDirection;
            
            return player;
        }

        List<Transform> LoadTrain(LevelSO levelData)
        {
            var prev = Instantiate(levelData.Carriages[0].gameObject, trainRoot);
            var sr = prev.GetComponent<SpriteRenderer>();
            var width = sr.bounds.size.x;
            prev.transform.localPosition = new Vector3(
                -width - carriagesOffset,
                0,
                0);
            var right = prev.transform.Find("RightBorder").GetComponent<CarriageBounds>();
            right.Init(CarriageBorderType.Wall); // Блок доступа в предыдущий вагон
            
            var result = new List<Transform>();
            
            for (var i = 1; i < levelData.Carriages.Count; ++i)
            {
                var carriage = CreateCarriage(
                    levelData.Carriages[i].gameObject,
                    i);

                result.Add(carriage);
            }

            return result;
        }

        void ExtendTrain()
        {
            var level = GetLevelSO();
            var newCarriages = level.Carriages;
            var nextIndex = G.CarriageManager.CarriageCount;

            for (var i = 1; i < newCarriages.Count; ++i)
            {
                var carriage = CreateCarriage(newCarriages[i].gameObject, nextIndex);
                if (i == 1)
                {
                    InitDestroyer(carriage.gameObject, nextIndex);
                }
                G.CarriageManager.ExtendTrain(carriage);

                ++nextIndex;
            }
        }

        Transform CreateCarriage(GameObject prefab, int index)
        {
            var carriageObject = Instantiate(prefab, trainRoot);

            carriageObject.transform.localPosition =
                new Vector3(_currentTrainX, 0, 0);

            var sr = carriageObject.GetComponent<SpriteRenderer>();

            _currentTrainX +=
                sr.bounds.size.x +
                carriagesOffset;

            var carriage =
                carriageObject.GetComponent<Carriage>();

            carriage.Number = index - 1;

            InitBorders(carriageObject);
            InitDialogue(carriageObject);

            return carriage.transform;
        }

        void InitBorders(GameObject carriageObject)
        {
            var left =
                carriageObject.transform.Find("LeftBorder")
                    ?.GetComponent<CarriageBounds>();

            var right =
                carriageObject.transform.Find("RightBorder")
                    ?.GetComponent<CarriageBounds>();

            left?.Init(CarriageBorderType.TransitionTrigger);

            right?.Init(CarriageBorderType.TransitionTrigger);
        }

        void InitDialogue(GameObject carriageObject)
        {
            var dialogue =
                carriageObject.transform.Find("DialoguePlace")
                    ?.GetComponent<DialogueTrigger>();

            dialogue?.Init(CarriageBorderType.DialoguePosTrigger);
        }

        void InitDestroyer(GameObject carriageObject, int index)
        {
            if (index <= 0 || G.CarriageManager == null)
                return;

            var destroyer =
                carriageObject.transform.Find("LeftBorder")
                    ?.GetComponent<ClearTrainTrigger>();

            destroyer?.Init(
                CarriageBorderType.ClearTrainTrigger,
                index - 1);
        }

        void OnDestroy()
        {
            G.DisposeLevel();
        }
    }
}
