using UnityEngine;

namespace Game.Scripts.DialogueModule
{
    [CreateAssetMenu(fileName = "DialogueData", menuName = "DialogueData")]
    public class DialogueData : ScriptableObject
    {
        public DialogueLine[] FullDialogue;
    }
}