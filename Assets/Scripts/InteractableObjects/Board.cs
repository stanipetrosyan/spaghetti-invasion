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


        public void Interact() {
            popup.Show();
            boardToZoom.UpdateImage(spriteToRender);
            
            GameManagers.Input.SetCanMove(false);
            GameManagers.Interact.Deactivate();
        }
    }
}