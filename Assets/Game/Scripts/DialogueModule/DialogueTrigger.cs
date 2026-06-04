using Game.Scripts.Infra;
using Game.Scripts.Triggers;
using UnityEngine;

namespace Game.Scripts.DialogueModule
{
    public class DialogueTrigger : Trigger
    {
        public DialogueData Dialogue;
        
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (BorderType is CarriageBorderType.DialoguePosTrigger)
            {
                G.LevelFlowController.EnterPhase(LevelPhase.Dialogue);
                G.DialogueSystem.StartDialogue(Dialogue);
            }
        }
    }
}