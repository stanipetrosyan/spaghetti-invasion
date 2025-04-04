using System;
using Managers;
using Port;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace InteractableObjects {
    public class Board : MonoBehaviour, Interactable {
        [SerializeField] private Popup popup;
        [SerializeField] private BoardsZoomedPopup boardToZoom;
        [SerializeField] private Sprite spriteToRender;
        private bool canInteract = true;


        public void Interact() {
            if (!canInteract) return;
            
            popup.Show();
            boardToZoom.UpdateImage(spriteToRender);
            
            GameManagers.Input.SetCanMove(false);
            GameManagers.Interact.Deactivate();
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