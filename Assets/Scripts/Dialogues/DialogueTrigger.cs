using System;
using System.Collections.Generic;
using Port;
using UnityEngine;

namespace Dialogues {
    [Serializable]
    public class DialogueCharacter{
        public string name;
        public Sprite icon;
    }


    [Serializable]
    public class DialogueLine{
        public DialogueCharacter character;
        [TextArea(3, 10)] public string line;
    }

    [Serializable]
    public class Dialogue{
        public List<DialogueLine> lines = new();
    }

    public class DialogueTrigger: MonoBehaviour, Interactable{
        public Dialogue dialogue;

        public void Interact() {
            Managers.GameManagers.Dialogue.StartDialogue(dialogue);
        }
    }
}