using System;
using UnityEngine;

namespace Dialogues {
    [Serializable]
    public class DialogueLine{
        
        public DialogueCharacter character;
        [TextArea(3, 10)] public string line;

        public DialogueLine(DialogueCharacter character,  string line) {
            this.character = character;
            this.line = line;
        }
    }
}