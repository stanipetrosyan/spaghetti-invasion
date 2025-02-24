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

            Debug.Log(PlayerPrefs.GetFloat("Volume", 0));
            Debug.Log(PlayerPrefs.GetInt("Quality", 0));
            Debug.Log(PlayerPrefs.GetInt("Fullscreen", 0));
            Debug.Log(PlayerPrefs.GetInt("Resolution", 0));
            

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
