using System;
using Port;
using TMPro;
using UnityEngine;

namespace Managers {
    public class InteractManager : MonoBehaviour, IManager{
        [SerializeField] private GameObject text;
        [SerializeField] private GameObject dialogueBox;
        private bool active = false;

        public void Activate() {
            active = true;
        }

        public void Deactivate() {
            active = false;
        }

        public ManagerStatus Status { get; set; }
        public void Startup() {
            Deactivate();
            Status = ManagerStatus.Started;
        }

        private void Update() {
            text.gameObject.SetActive(active && !dialogueBox.activeSelf);
        }
    }
}