using System;
using System.Collections.Generic;
using Game.Scripts.DialogueModule;
using Game.Scripts.Infra;
using UnityEngine;

public class LevelFlowController
{
    public LevelPhase CurrentPhase { get; private set; }
    public CharacterController CharacterController { get; private set; }
    public DialogueSystem DialogueSystem { get; private set; }

    public LevelFlowController(DialogueSystem dialogueSystem)
    {
        DialogueSystem = dialogueSystem;
    }

    public event Action OnLevelComplete;
    public event Action<LevelPhase> OnPhaseChange;
    public event Action OnZoom;
    public event Action OnZoomReset;
    public event Action OnEditZoom;
    public event Action OnEditZoomReset;
    
    private LevelPhase _prevPhase = LevelPhase.Gameplay;
    
    public void StartLevel() => EnterPhase(LevelPhase.Gameplay);
    
    public void SetCharacter(CharacterController characterController) => CharacterController = characterController;

    public void EnterPhase(LevelPhase levelPhase)
    {
        _prevPhase = CurrentPhase;
        CurrentPhase = levelPhase;
        OnPhaseChange?.Invoke(levelPhase);

        switch (levelPhase)
        {
            case LevelPhase.Gameplay:
                CharacterController.OnGameplayResume?.Invoke();
                if (_prevPhase is LevelPhase.Edit)
                    OnEditZoomReset?.Invoke();
                Debug.Log("Началась фаза геймплея!");
                break;
            case LevelPhase.Edit:
                OnEditZoom?.Invoke();
                Debug.Log("Началась фаза редактуры!");
                break;
            case LevelPhase.Dialogue:
                CharacterController.OnGameplayStop?.Invoke();
                DialogueSystem.OnDialogueEnd += OnDialogueEnded;
                Debug.Log("Началась фаза диалога!");
                break;
            case LevelPhase.Story:
                Debug.Log("Началась фаза истории! (комикс/картинка, что мы там выдумаем)");
                break;
        }
    }
    
    public void Zoom()
    {
        OnZoom?.Invoke();
    }
    
    public void ResetCameraZoom()
    {
        OnZoomReset?.Invoke();
    }

    private void OnDialogueEnded()
    {
        Debug.Log("Диалог завершён!");
        DialogueSystem.OnDialogueEnd -= OnDialogueEnded;
        FinishLevel();
    }

    public void FinishLevel()
    {
        Debug.Log("Уровень завершён!");
        G.SaveManager.EndLevel();
        OnLevelComplete?.Invoke();
        EnterPhase(LevelPhase.Gameplay);
    }
    
    public void Pause() => Time.timeScale = 0;
    public void Resume() => Time.timeScale = 1;
}
