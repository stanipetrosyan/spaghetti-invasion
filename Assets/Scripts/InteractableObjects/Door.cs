using System;
using System.Collections.Generic;
using Dialogues;
using Inventory;
using Managers;
using Port;
using UnityEngine;

namespace InteractableObjects {
    public class Door : MonoBehaviour, Interactable {
        [SerializeField] private Dialogue success;
        [SerializeField] private Dialogue failure;
        [SerializeField] private List<UsableItem> usableItems = new List<UsableItem>();
        private bool activated = false;
        private bool canInteract = true;

        public void Interact() {
            var index = 0;

            while (activated == false && index < usableItems.Count) {
                activated = UseItem(usableItems[index]);

                index++;
            }

            if (activated) {
                gameObject.SetActive(false);
                GameManagers.Dialogue.StartDialogue(success);
            }
            else {
                GameManagers.Dialogue.StartDialogue(failure);
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

        private bool UseItem(UsableItem item) {
            List<UsableItem> keys = GameManagers.Inventory.GetAllOfType(item.type);
            UnityEngine.Debug.Log(item.type);

            if (keys.Count <= 0) return false;

            GameManagers.Inventory.Use(keys[0]);

            return true;
        }
    }
}