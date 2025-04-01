using Dialogues;
using UnityEngine;

namespace InteractableObjects {
    [RequireComponent(typeof(DialogueTrigger))]
    public class ObjectWithoutItem : MonoBehaviour, Port.Interactable{
        private DialogueTrigger dialogueTrigger;

        private void Start() {
            dialogueTrigger = GetComponent<DialogueTrigger>();
        }

        public void Interact() {
            if (dialogueTrigger) {
                dialogueTrigger.StartDialogue();
            }
        }

        public void Enable() {
            throw new System.NotImplementedException();
        }

        public void Disable() {
            throw new System.NotImplementedException();
        }
    }
}