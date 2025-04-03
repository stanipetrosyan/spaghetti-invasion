using Port;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
    public class GameOverManager: MonoBehaviour, IManager {

        public string gameOverReason;
        public ManagerStatus Status { get; set; }

        public void Startup() {
            Status = ManagerStatus.Started;
        }

        public void GameOver(string reason) {
            gameOverReason = reason;
            SceneManager.LoadScene("GameOver");
        }
    }
}