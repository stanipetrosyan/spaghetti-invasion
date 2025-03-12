using System;
using UnityEngine;

namespace Dialogues {
    [CreateAssetMenu(fileName = "DialogueCharacter", menuName = "ScriptableObjects/DialogueCharacter")]
    public class DialogueCharacter: ScriptableObject{
        public string displayName;
        public Sprite icon;
    }
} 