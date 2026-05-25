using System;
using Game.Scripts.Infra;
using UnityEngine;

public class LevelFlowController
{
    public LevelPhase CurrentPhase { get; private set; }
    
    public event Action<LevelPhase> OnPhaseChange;
    public void StartLevel() => EnterPhase(LevelPhase.Gameplay);

    public void EnterPhase(LevelPhase levelPhase)
    {
        CurrentPhase = levelPhase;
        OnPhaseChange?.Invoke(levelPhase);

        switch (levelPhase)
        {
            case LevelPhase.Gameplay:
                Debug.Log("Началась фаза геймплея!");
                break;
            case LevelPhase.Dialogue:
                Debug.Log("Началась фаза диалога!");
                break;
            case LevelPhase.Story:
                Debug.Log("Началась фаза истории! (комикс/картинка, что мы там выдумаем)");
                break;
        }
    }
}
