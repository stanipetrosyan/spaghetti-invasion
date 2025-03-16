using Port;
using UnityEngine;

namespace Managers {
    public class InputManager: MonoBehaviour, IManager {
        public ManagerStatus Status { get; set; }
        public void Startup() {
            Status = ManagerStatus.Started;
        }

        public bool CanMove() {
            return true;
        }
        
        
    }
}