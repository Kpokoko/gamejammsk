using UnityEngine;

namespace Game.Scripts.Infra
{
    public class LevelBootstrap : MonoBehaviour
    {
        void Awake()
        {
            G.InitLevel(new LevelFlowController());
            
            var levelData = G.LevelsDatabase.Levels[G.SaveManager.Data.CurrentLevelIndex];
            var playerSpawnPos = levelData.PlayerSpawnPoint;
            var player =
                Instantiate(GameResources.Prefabs.Player,
                    new Vector3(playerSpawnPos.x, playerSpawnPos.y, 0),
                    Quaternion.identity);
            player.GetComponent<CharacterController>().MoveDirection = levelData.MoveDirection;
            
            G.LevelFlowController.StartLevel();
        }

        void OnDestroy()
        {
            G.DisposeLevel();
        }
    }
}
