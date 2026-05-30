using System.Collections.Generic;
using Game.Scripts.DialogueModule;
using UnityEngine;

namespace Game.Scripts.Infra
{
    [CreateAssetMenu(fileName = "LevelSO", menuName = "LevelSO")]
    public class LevelSO : ScriptableObject
    {
        public int LevelIndex;
        public List<CarriageConfig> Carriages; //#TODO в принципе это сделать лол
        public Vector2 PlayerSpawnPoint; // Чуть инвалидно, но потерпим, как будто бы...
        public MoveDirection MoveDirection;
    }
}