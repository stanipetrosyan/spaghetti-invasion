using System.Collections.Generic;
using Dialogues;
using Inventory;
using Managers;
using Port;
using UnityEngine;

namespace InteractableObjects {
    public class Altar : MonoBehaviour, Interactable {
        [SerializeField] private Dialogue dialogue;
        [SerializeField] private List<UsableItem> items = new();
        [SerializeField] private bool destroyOnInteract;
        private InteractableObjectLight objectLight;
        public bool interacted = false;

        private void Start() {
            objectLight = GetComponent<InteractableObjectLight>();
        }

        public void Interact() {
            if (interacted) return;
            
            GameManagers.Inventory.Add(items);
            GameManagers.Dialogue.StartDialogue(dialogue);
            interacted = true;
            
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