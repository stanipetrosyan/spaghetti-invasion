using Port;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InteractableObjects {
    public class Console: MonoBehaviour, Interactable {
        private bool canInteract = true;
        
        public void Interact() {
            SceneManager.LoadScene("Outro");
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