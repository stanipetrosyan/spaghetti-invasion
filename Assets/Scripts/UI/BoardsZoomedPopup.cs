using Managers;
using Port;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class BoardsZoomedPopup : MonoBehaviour{
        [SerializeField] private Image board;
        [SerializeField] private TextMeshProUGUI closeText;

        private void Start() {
            gameObject.SetActive(false);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.X)) {
                gameObject.SetActive(false);
                GameManagers.Input.SetCanMove(true);
            }
        }
    }
}