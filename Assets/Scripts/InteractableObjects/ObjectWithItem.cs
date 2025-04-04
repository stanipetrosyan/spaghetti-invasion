using System.Collections.Generic;
using Dialogues;
using Inventory;
using Managers;
using UnityEngine;

namespace InteractableObjects {
    [RequireComponent(typeof(DialogueTrigger))]
    public class ObjectWithItem : MonoBehaviour, Port.Interactable{
        private DialogueTrigger dialogueTrigger;
        [SerializeField] private List<UsableItem> items = new();
        [SerializeField] private bool destroyOnInteract;
        private InteractableObjectLight objectLight;
        public bool interacted = false;

        private void Start() {
            objectLight = GetComponent<InteractableObjectLight>();
            dialogueTrigger = GetComponent<DialogueTrigger>();
        }

        public void Interact() {
            if (interacted) return;
            GameManagers.Inventory.Add(items);

            if (dialogueTrigger) {
                dialogueTrigger.StartDialogue();
                interacted = true;
            }
            if (destroyOnInteract) {
                gameObject.SetActive(false);
            }
            if (objectLight) {
                objectLight.DeActivate();
            }
        }

        public void Enable() {
            interacted = false;
        }

        public void Disable() {
            interacted = true;
        }

        public bool CanInteract() {
            return !interacted;
        }
    }
}