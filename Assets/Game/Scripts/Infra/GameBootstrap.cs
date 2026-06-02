using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Infra
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private LevelsDatabaseSO levelsDatabase;
        [SerializeField] private SoundManager soundManager;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            var saveManager = new SaveManager();
            soundManager.musicVolume = saveManager.Data.MusicVolume;
            soundManager.sfxVolume = saveManager.Data.SfxVolume;
            DontDestroyOnLoad(soundManager);
            G.InitGame(levelsDatabase, saveManager, soundManager);
        }
    }
}