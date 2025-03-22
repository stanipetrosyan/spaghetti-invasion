using Dialogues;
using UnityEngine;

namespace Interactable {
    [RequireComponent(typeof(DialogueTrigger))]
    public class ObjectWithoutItem : MonoBehaviour, Port.Interactable{
        private DialogueTrigger dialogueTrigger;

        private void Start() {
            dialogueTrigger = GetComponent<DialogueTrigger>();
        }

        public void Interact() {
            Debug.Log("Interacted");

            if (dialogueTrigger) {
                dialogueTrigger.StartDialogue();
            }
        }
    }
}