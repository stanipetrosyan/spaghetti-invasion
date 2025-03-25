using Port;
using TMPro;
using UnityEngine;

namespace Managers {
    public class InteractManager : MonoBehaviour, IManager{
        [SerializeField] private GameObject text;

        public void Activate() {
            text.gameObject.SetActive(true);
        }

        public void Deactivate() {
            text.gameObject.SetActive(false);
        }

        public ManagerStatus Status { get; set; }
        public void Startup() {
            Deactivate();
            Status = ManagerStatus.Started;
        }
    }
}