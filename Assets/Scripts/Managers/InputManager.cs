using Port;
using UI;
using UnityEngine;

namespace Managers {
    public class InputManager: MonoBehaviour, IManager {
        [SerializeField] private Popup settings;
        private bool canMove;
        public ManagerStatus Status { get; set; }
        public void Startup() {
            canMove = true;
            Status = ManagerStatus.Started;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                // open game menu
            }
        }

        public bool CanMove() {
            return canMove;
        }

        public void SetCanMove(bool move) {
            this.canMove = move;
        }
    }
}