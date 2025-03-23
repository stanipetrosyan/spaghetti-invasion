using UnityEngine;

namespace UI {
    public class Popup: MonoBehaviour {

        [SerializeField] private GameObject panel;
        private void Start() {
            Hide();
        }

        public void Show() {
            panel.SetActive(true);
        }

        public void Hide() {
            panel.SetActive(false);
        }
    }
}