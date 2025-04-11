using Port;
using UnityEngine;

namespace InteractableObjects {
    public class Console: MonoBehaviour, Interactable {
        private bool canInteract = true;
        
        public void Interact() {
            if (canInteract) {
                canInteract = false;
            }
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