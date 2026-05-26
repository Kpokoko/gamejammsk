using Game;
using Game.Scripts.Infra;
using Game.Scripts.Managers;
using UnityEngine;

public static class G // Сервис-локатор
{
    #region AlwaysAlive
    
    // То, что создаётся при старте и живёт всегда

    public static SoundManager SoundManager { get; private set; }
    public static SaveManager SaveManager { get; private set; }
    public static LevelsDatabaseSO LevelsDatabase { get; private set; }

    #endregion

    #region MenuOnly

    // То, что живёт только в меню (ui меню, по большей части)

    #endregion

    #region LevelOnly
    
    // То, что необходимо только на уровне (ui уровня, флоу контроллер и т.д.)
    public static LevelFlowController LevelFlowController { get; private set; }
    public static CarriageManager CarriageManager { get; private set; }

    #endregion

    // инициализация/подсос AlwaysAlive сервисов
    public static void InitGame(LevelsDatabaseSO levelsDatabase, SaveManager saveManager)
    {
        LevelsDatabase = levelsDatabase;
        SaveManager = saveManager;
    }

    // инициализация/подсос MenuOnly сервисов
    public static void InitMenu()
    {
        
    }

    // очистка MenuOnly сервисов
    public static void DisposeMenu()
    {
        
    }
    
    // инициализация/подсос LevelOnly сервисов
    public static void InitLevel(
        LevelFlowController levelFlowController,
        CarriageManager carriageManager)
    {
        LevelFlowController = levelFlowController;
        CarriageManager = carriageManager;
    }

    // очистка LevelOnly сервисов
    public static void DisposeLevel()
    {
        LevelFlowController = null;
    }
}
