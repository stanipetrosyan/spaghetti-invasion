using Managers;
using UnityEngine;

namespace Dialogues {
    public class DialogueTrigger: MonoBehaviour{
        public Dialogue dialogue;
        private bool interacted = false;

        public void StartDialogue() {
            if (interacted) return;
            
            Debug.Log("Starting dialogue");
            
            GameManagers.Dialogue.StartDialogue(dialogue);
            GameManagers.Input.SetCanMove(false);
            interacted = true;
        }
    }
}