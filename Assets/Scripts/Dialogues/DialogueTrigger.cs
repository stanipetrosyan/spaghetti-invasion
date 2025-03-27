using Managers;
using Port;
using UnityEngine;

namespace Dialogues {
    public class DialogueTrigger: MonoBehaviour, Interactable{
        public Dialogue dialogue;
        private bool interacted = false;

        public void StartDialogue() {
            if (interacted) return;
            
            GameManagers.Dialogue.StartDialogue(dialogue);
            GameManagers.Input.SetCanMove(false);
            interacted = true;
        }

        public void Interact() {
            StartDialogue();
        }
    }
}