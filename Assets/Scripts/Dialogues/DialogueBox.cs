using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogues {
    public class DialogueBox: MonoBehaviour {
        public Image characterIcon;
        public TextMeshProUGUI characterName;
        public TextMeshProUGUI dialogueArea;
        
        private Queue<DialogueLine> dialogueLines = new();

        public bool isDialogueActive = false;

        public float typingSpeed = 0.2f;
        
        public void StartDialogue(Dialogue dialogue) {
            if (isDialogueActive) return;

            isDialogueActive = true;
            
            dialogueLines.Clear();

            foreach (var line in dialogue.lines) {
                dialogueLines.Enqueue(line);
            }

            DisplayNextDialogueLine();
        }

        private void DisplayNextDialogueLine() {
            if (dialogueLines.Count ==  0) {
                EndDialogue();
                return;
            }  
            
            var currentLine = dialogueLines.Dequeue();

            characterIcon.sprite = currentLine.character.icon;
            characterName.text = currentLine.character.name;

            StopAllCoroutines();

            StartCoroutine(TypeSentence(currentLine));
        }

        private IEnumerator TypeSentence(DialogueLine currentLine) {
            dialogueArea.text = "";
            foreach (var letter in currentLine.line) {
                dialogueArea.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        private void EndDialogue() {
            isDialogueActive = false;
        }
    }
}