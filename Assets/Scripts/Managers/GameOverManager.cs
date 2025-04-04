using Port;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
    public class GameOverManager: MonoBehaviour, IManager {

        public ManagerStatus Status { get; set; }

        public void Startup() {
            Status = ManagerStatus.Started;
        }

        public void GameOver(string reason) {
            PlayerPrefs.SetString("GameOverReason", reason);
            SceneManager.LoadScene("GameOver");
        }
    }
}