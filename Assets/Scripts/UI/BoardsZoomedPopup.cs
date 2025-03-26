using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Screen;

namespace UI {
    public class BoardsZoomedPopup : MonoBehaviour{
        [SerializeField] private Image board;
        [SerializeField] private TextMeshProUGUI closeText;

        public void UpdateImage(Sprite sprite) {
            board.sprite = sprite;
        }
        
        private void Update() {
            if (Input.GetKeyDown(KeyCode.X)) {
                gameObject.SetActive(false);
                GameManagers.Input.SetCanMove(true);
            }
        }
    }
}