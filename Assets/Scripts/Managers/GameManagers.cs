using System.Collections;
using System.Collections.Generic;
using Port;
using UnityEngine;

namespace Managers{
    public class GameManagers : MonoBehaviour {
        public static DialogueManager Dialogue { get; private set; }
        public static AudioManager Audio { get; private set; }
        
        public static InventoryManager Inventory { get; private set; }
        public static InputManager Input { get; private set; }
        public static InteractManager Interact { get; private set; }
        
        private List<IManager> startSequence;


        void Awake() {
            Dialogue = GetComponent<DialogueManager>();
            Audio = GetComponent<AudioManager>();
            Inventory = GetComponent<InventoryManager>();
            Input = GetComponent<InputManager>();
            Interact = GetComponent<InteractManager>();
            
            startSequence = new List<IManager>() {
                Input,
                Dialogue,
                Audio,
                Inventory,
                Interact
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
