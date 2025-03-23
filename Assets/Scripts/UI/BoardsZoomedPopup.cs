using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Screen;

namespace UI {
    public class BoardsZoomedPopup : MonoBehaviour{
        [SerializeField] private Image board;
        [SerializeField] private TextMeshProUGUI closeText;

        private void Start() {
            //this.transform.position = new Vector3(width / 2, height / 2, 0);
        }
        
        private void Update() {
            if (Input.GetKeyDown(KeyCode.X)) {
                gameObject.SetActive(false);
                GameManagers.Input.SetCanMove(true);
            }
        }
    }
}