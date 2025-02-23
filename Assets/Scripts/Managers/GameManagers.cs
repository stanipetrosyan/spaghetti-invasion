using System.Collections;
using System.Collections.Generic;
using Port;
using UnityEngine;

namespace Managers{
    public class GameManagers : MonoBehaviour {
        public static DialogueManager Dialogue { get; private set; }
        
        private List<IManager> startSequence;


        void Awake() {
            Dialogue = GetComponent<DialogueManager>();
            
            startSequence = new List<IManager>() {
                Dialogue,
            };

            StartCoroutine(StartupManagers());
        }

        private IEnumerator StartupManagers() {
            foreach (var manager in startSequence) {
                manager.Startup();
            }

            yield return null;
            
        }
        
    }
}
