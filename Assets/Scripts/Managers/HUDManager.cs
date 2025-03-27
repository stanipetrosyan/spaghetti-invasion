using Port;
using UnityEngine;

namespace Managers {
    public class HUDManager: MonoBehaviour, IManager {
        public void ExitGame() {
            Application.Quit();
        }

        public ManagerStatus Status { get; set; }
        public void Startup() {
            Status = ManagerStatus.Started;
        }
    }
}