using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Infra
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private LevelsDatabaseSO levelsDatabase;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            var saveManager = new SaveManager();
            G.InitGame(levelsDatabase, saveManager);
            SceneManager.LoadScene("Game");
        }
    }
}