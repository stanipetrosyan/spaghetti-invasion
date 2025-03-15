using System.Collections;
using System.Collections.Generic;
using Dialogues;
using UnityEngine;

namespace Prison {
    public class StartDialogue: MonoBehaviour{
        [SerializeField] private DialogueCharacter characterController;
        private DialogueTrigger dialogueTrigger;
        private Dialogue dialogue;
        
        private void Start() {
            dialogueTrigger = GetComponent<DialogueTrigger>();
            dialogueTrigger.dialogue = CreateDialogue("Ehi, you!... Can you hear me?");
            
            StartCoroutine(WaitForDialogue());
            
            dialogueTrigger = GetComponent<DialogueTrigger>();
            dialogueTrigger.dialogue = CreateDialogue("I know you can! To the wall! The broken tile!");
            
            StartCoroutine(WaitForDialogue());
            
            dialogueTrigger = GetComponent<DialogueTrigger>();
            dialogueTrigger.dialogue = CreateDialogue("I was certain I heard someone…");
            
            StartCoroutine(WaitForDialogue());
        }

        private Dialogue CreateDialogue(string line) {
            dialogue = new Dialogue();
            var dialogueLines = new List<DialogueLine> { new(characterController, line) };

            dialogue.lines = dialogueLines;
            return dialogue;
        }
        

        private IEnumerator WaitForDialogue() {
            Debug.Log("Waiting for dialogue");
            yield return new WaitForSeconds(2f);
            
            dialogueTrigger.StartDialogue();
        }

    }
}