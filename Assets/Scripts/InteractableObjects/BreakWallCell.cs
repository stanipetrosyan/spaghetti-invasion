using Dialogues;
using Port;
using Prison;
using UnityEngine;

namespace InteractableObjects {
    public class BreakWallCell: MonoBehaviour, Interactable {
        [SerializeField] private CellsWorkflow workflow;
        private DialogueTrigger dialogueTrigger;
        private bool canInteract = true;

        private void Start() {
            dialogueTrigger = GetComponent<DialogueTrigger>();
        }
        
        public void Interact() {
            workflow.EnableInteraction();
            
            dialogueTrigger.StartDialogue();
        }

        public void Enable() {
            canInteract = true;
        }

        public void Disable() {
            canInteract = false;
        }
    }
}