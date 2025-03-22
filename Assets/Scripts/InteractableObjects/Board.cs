using Managers;
using Port;
using UnityEngine;

namespace InteractableObjects {
    public class Board : MonoBehaviour, Interactable {
        [SerializeField] private Popup boardZoomed;


        public void Interact() {
            boardZoomed.Show();

            GameManagers.Input.SetCanMove(false);
            GameManagers.Interact.Deactivate();
        }
    }
}