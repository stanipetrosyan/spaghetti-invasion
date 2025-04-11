using System.Collections;
using Dialogues;
using Managers;
using Port;
using UnityEngine;

namespace Workflows {
    public class GraveyardWorkflow: MonoBehaviour, Workflow {
        [SerializeField] private Player player;
        [SerializeField] private Dialogue climaxDialogue;
        [SerializeField] private Dialogue calmDialogue;
        
        private bool triggered = false;
        private bool climaxTriggered = false;
        

        private void Update() {
            if (!triggered) return;
            if(climaxTriggered) return;
            
            if (GameManagers.Dialogue.IsActiveDialogue()) {
                player.MaximizeAnxiety();
            }
            else {
                climaxTriggered = true;
                player.MinimizeAnxiety();
                StartCoroutine(WaitCalmDialogue());
            }
        }
        
        public void Trigger() {
            if(triggered) return;
            
            
            GameManagers.Input.SetCanMove(false);
            triggered = true;
            GameManagers.Audio.StopPrisonAudio();
            
            GameManagers.Dialogue.StartDialogue(climaxDialogue);
        }

        private IEnumerator WaitCalmDialogue() {
            yield return new WaitForSeconds(5f);
            GameManagers.Dialogue.StartDialogue(calmDialogue);
            yield return new WaitForSeconds(10f);
            GameManagers.Audio.PlayPrisonAudio();
            GameManagers.Input.SetCanMove(true);
            gameObject.SetActive(false);
            
        }
    }
    
    
}