using System;
using DG.Tweening;
using Game.Scripts.DialogueModule;
using Game.Scripts.Infra;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    [SerializeField] private Image speaker;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text speakerName;
    [SerializeField] private GameObject dialoguePanel;
    
    private DialogueSystem _dialogueSystem;
    private Tween _typingTween;

    public void Start()
    {
        _dialogueSystem = G.DialogueSystem;
        _dialogueSystem.OnLineShow += ShowLine;
        _dialogueSystem.OnDialogueEnd += Hide;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnDialogueClicked();
    }

    void ShowLine(DialogueLine line)
    {
        if (!dialoguePanel.activeSelf)
            dialoguePanel.SetActive(true);
        speaker.sprite = line.Speaker;
        speakerName.text = line.SpeakerName;
        
        text.text = line.Dialogue;
        text.maxVisibleCharacters = 0;

        _typingTween?.Kill();
        _typingTween = DOTween.To(
            () => text.maxVisibleCharacters,
            x => text.maxVisibleCharacters = x,
            line.Dialogue.Length,
            line.Dialogue.Length * 0.05f  // ~50мс на символ
        ).SetEase(Ease.Linear);
    }
    
    public void OnDialogueClicked()
    {
        if (G.LevelFlowController.CurrentPhase is not LevelPhase.Dialogue)
            return;
        if (_typingTween != null && _typingTween.IsActive() && !_typingTween.IsComplete())
        {
            _typingTween.Complete();
        }
        else
        {
            _dialogueSystem.Next();
        }
    }

    void Hide()
    {
        dialoguePanel.SetActive(false);
    }

    void OnDestroy()
    {
        if (_dialogueSystem == null) return;
        _dialogueSystem.OnLineShow -= ShowLine;
        _dialogueSystem.OnDialogueEnd -= Hide;
    }
}
