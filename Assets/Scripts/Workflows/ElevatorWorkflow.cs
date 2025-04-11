using System;
using System.Collections;
using Dialogues;
using Managers;
using Port;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Workflows {
    public class ElevatorWorkflow: MonoBehaviour, Workflow {

        [SerializeField] private Player player;
        [SerializeField] private GameObject DoorToClose;
        [SerializeField] private GameObject DoorToOpen;
        [SerializeField] private Light2D light2D;
        private DialogueTrigger dialogueTrigger;
        private bool triggered = false;

        private void Start() {
            DoorToClose.SetActive(false);
            DoorToOpen.SetActive(true);
            light2D.enabled = false;
            
            dialogueTrigger = DoorToOpen.GetComponent<DialogueTrigger>();
            
        }

        private void Update() {
            if (!triggered) return;
            
            if (!dialogueTrigger.CanInteract()) {
                StartCoroutine(WaitElevator());
            }

        }

        private IEnumerator WaitElevator() {
            yield return new WaitForSeconds(5f);
            DoorToOpen.SetActive(false);
            light2D.enabled = true;
            GameManagers.Audio.PlayControlRoomAudio();
            gameObject.SetActive(false);
        }


        public void Trigger() {
            player.DeactivateLight();
            GameManagers.Audio.StopAll();
            DoorToClose.SetActive(true);
            triggered = true;
        }
    }
}