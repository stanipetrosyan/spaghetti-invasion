using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InteractableObjects {
    public class Board : MonoBehaviour, Port.Interactable{
    
        [SerializeField] private Image board;
        [SerializeField] private TextMeshProUGUI closeText;

        public void Interact() {
            board.gameObject.SetActive(true);
            closeText.gameObject.SetActive(true);
            GameManagers.Input.SetCanMove(false);
            GameManagers.Interact.Deactivate();
        }
    }
}
