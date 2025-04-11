using Port;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
    public class MainMenuController : MonoBehaviour{
        [SerializeField] private Popup settings;
        [SerializeField] private Popup credits;

        public void StartGame() {
            SceneManager.LoadScene("Intro");
        }

        public void QuitGame() {
            Application.Quit();
        }

        public void OpenSettings() {
            settings.Show();
            credits.Hide();
        }

        public void CloseSettings() {
            settings.Hide();
        }

        public void OpenCredits() {
            credits.Show();
            settings.Hide();
        }

        public void CloseCredits() {
            credits.Hide();
        }
    
    }
}
