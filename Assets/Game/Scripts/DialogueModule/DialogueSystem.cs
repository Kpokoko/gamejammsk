using System;

namespace Game.Scripts.DialogueModule
{
    public class DialogueSystem
    {
        private DialogueData _dialogueData;
        private int _currentDialogueIndex;
        
        public Action<DialogueLine> OnLineShow;
        public Action OnDialogueEnd;

        public void StartDialogue(DialogueData dialogueData)
        {
            _dialogueData = dialogueData;
            _currentDialogueIndex = 0;
            ShowCurrentLine();
        }

        void ShowCurrentLine() => OnLineShow?.Invoke(_dialogueData.FullDialogue[_currentDialogueIndex]);

        public void Next()
        {
            _currentDialogueIndex++;

            if (_currentDialogueIndex >= _dialogueData.FullDialogue.Length)
            {
                OnDialogueEnd?.Invoke();
                return;
            }

            ShowCurrentLine();
        }
    }
}