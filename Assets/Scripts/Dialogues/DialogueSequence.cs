using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Dialogues {
    public class DialogueSequence : MonoBehaviour {
        [SerializeField] private List<Dialogue> dialogueList;
        public float timeBetweenDialogues = 3f;
        private bool finished = false;


        private void Start() {
            StartCoroutine(WaitDialogue());
        }


        private IEnumerator WaitDialogue() {
            foreach (var dialogue in dialogueList) {
                yield return new WaitForSeconds(timeBetweenDialogues);

                CutsceneManagers.Dialogue.StartDialogue(dialogue);
            }
            
            finished = true;
        }

        public bool IsFinished() {
            return finished;
        }
    }
}