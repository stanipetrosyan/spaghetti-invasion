using Managers;
using Port;
using UnityEngine;

namespace Dialogues {
    public class DialogueTrigger: MonoBehaviour, Interactable {
        public Dialogue dialogue;
        private bool canInteract = true;

        public void StartDialogue() {
            if (!canInteract) return;
            
            GameManagers.Dialogue.StartDialogue(dialogue);
            GameManagers.Input.SetCanMove(false);
            Disable();
        }

        public void Interact() {
            StartDialogue();
        }

        public void Enable() {
            canInteract = true;
        }

        public void Disable() {
            canInteract = false;
        }

        public bool CanInteract() {
            return canInteract;
        }
    }
}