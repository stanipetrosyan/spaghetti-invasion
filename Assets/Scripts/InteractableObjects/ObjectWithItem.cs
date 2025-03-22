using System.Collections.Generic;
using Dialogues;
using Inventory;
using Managers;
using UnityEngine;

namespace Interactable {
    [RequireComponent(typeof(DialogueTrigger))]
    public class ObjectWithItem : MonoBehaviour, Port.Interactable{
        private DialogueTrigger dialogueTrigger;
        [SerializeField] private List<UsableItem> items = new();
        private bool interacted = false;

        private void Start() {
            dialogueTrigger = GetComponent<DialogueTrigger>();
        }

        public void Interact() {
            if (interacted) return;
            Debug.Log("Interacted");
            GameManagers.Inventory.Add(items);

            if (dialogueTrigger) {
                dialogueTrigger.StartDialogue();
                interacted = true;
            }
        }
    }
}