using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogues {
    public class DialogueBox : MonoBehaviour {
        [SerializeField] private Image characterIcon;
        [SerializeField] private TextMeshProUGUI characterName;
        [SerializeField] private TextMeshProUGUI dialogueArea;
        [SerializeField] private Button nextDialogueButton;

        private readonly Queue<DialogueLine> dialogueLines = new();

        public bool isDialogueActive = false;

        private const float TypingSpeed = 0.05f;

        private void Start() {
            gameObject.SetActive(false);
            nextDialogueButton.onClick.AddListener(DisplayNextDialogueLine);
        }

        public void StartDialogue(Dialogue dialogue) {
            if (isDialogueActive) return;

            isDialogueActive = true;

            dialogueLines.Clear();

            foreach (var line in dialogue.lines) {
                dialogueLines.Enqueue(line);
            }

            DisplayNextDialogueLine();
        }

        void DisplayNextDialogueLine() {
            if (dialogueLines.Count == 0) {
                EndDialogue();
                return;
            }

            var currentLine = dialogueLines.Dequeue();

            characterIcon.sprite = currentLine.character.icon;
            characterName.text = currentLine.character.displayName;

            StopAllCoroutines();

            StartCoroutine(TypeSentence(currentLine));
        }

        private IEnumerator TypeSentence(DialogueLine currentLine) {
            dialogueArea.text = "";
            foreach (var letter in currentLine.line) {
                dialogueArea.text += letter;
                yield return new WaitForSeconds(TypingSpeed);
            }
        }

        private void EndDialogue() {
            isDialogueActive = false;
            gameObject.SetActive(false);
        }
    }
}