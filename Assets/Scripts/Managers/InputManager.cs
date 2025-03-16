using Port;
using UnityEngine;

namespace Managers {
    public class InputManager: MonoBehaviour, IManager {
        private bool canMove;
        public ManagerStatus Status { get; set; }
        public void Startup() {
            canMove = true;
            Status = ManagerStatus.Started;
        }

        public bool CanMove() {
            return canMove;
        }

        public void SetCanMove(bool move) {
            this.canMove = move;
        }
    }
}