using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Dialogues {
    public class DialogueSequence : MonoBehaviour {
        [SerializeField] private List<Dialogue> dialogueList;
        public float timeBetweenDialogues = 3f;


        private void Start() {
            StartCoroutine(WaitDialogue());
        }


        private IEnumerator WaitDialogue() {
            foreach (var dialogue in dialogueList) {
                yield return new WaitForSeconds(timeBetweenDialogues);

                GameManagers.Dialogue.StartDialogue(dialogue);
            }
        }
    }
}