using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Infra
{
    [CreateAssetMenu(fileName = "LevelDatavaseSO", menuName = "LevelDatavaseSO")]
    public class LevelsDatabaseSO : ScriptableObject
    {
        public List<LevelSO> Levels;
    }
}