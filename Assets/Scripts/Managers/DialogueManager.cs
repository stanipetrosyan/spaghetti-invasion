using Dialogues;
using Port;
using UnityEngine;

namespace Managers{
    public class DialogueManager: MonoBehaviour, IManager {
        [SerializeField] private DialogueBox dialogueBox;
        
        public ManagerStatus Status { get; set; }

        public void Startup() {
            Status = ManagerStatus.Started;
        }

        public void StartDialogue(Dialogue dialogue) {
            dialogueBox.gameObject.SetActive(true);
            dialogueBox.StartDialogue(dialogue);
        }
    }
}