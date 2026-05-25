using UnityEngine;

namespace Game.Scripts.Infra
{
    public class GameBootstrap : MonoBehaviour // Сейчас висит на том же объекте, что и levelbootstrap, жёсткий костыль, надо будет выпиливать как можно быстрее
    {
        [SerializeField] private LevelsDatabaseSO levelsDatabase;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            var saveManager = new SaveManager();
            G.InitGame(levelsDatabase, saveManager);
        }
    }
}