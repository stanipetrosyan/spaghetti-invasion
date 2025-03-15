using Managers;
using Port;
using UnityEngine;

namespace Dialogues {
    public class DialogueTrigger: MonoBehaviour{
        public Dialogue dialogue;
        private bool interacted = false;

        public void StartDialogue() {
            if (interacted) return;
            
            GameManagers.Dialogue.StartDialogue(dialogue);
            interacted = true;
        }
    }
}