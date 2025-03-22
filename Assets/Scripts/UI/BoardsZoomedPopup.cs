using Managers;
using Port;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    [RequireComponent(typeof(Popup))]
    public class BoardsZoomedPopup : MonoBehaviour{
        [SerializeField] private Image board;
        [SerializeField] private TextMeshProUGUI closeText;
        
        void Start() {
            
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.X)) {
                gameObject.SetActive(false);
                GameManagers.Input.SetCanMove(true);
            }
        }
    }
}