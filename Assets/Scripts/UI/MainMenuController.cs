using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
    public class MainMenuController : MonoBehaviour{
        [SerializeField] private Popup settings;
        [SerializeField] private Popup credits;

        public void StartGame() {
            SceneManager.LoadScene("Game");
        }

        public void QuitGame() {
            Application.Quit();
        }

        public void OpenSettings() {
            settings.Show();
        }

        public void CloseSettings() {
            settings.Hide();
        }

        public void OpenCredits() {
            credits.Show();
        }

        public void CloseCredits() {
            credits.Hide();
        }
    
    }
}
