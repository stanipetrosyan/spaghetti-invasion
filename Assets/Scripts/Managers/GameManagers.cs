using System.Collections;
using System.Collections.Generic;
using Port;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Managers{
    public class GameManagers : MonoBehaviour {
        public static DialogueManager Dialogue { get; private set; }
        public static AudioManager Audio { get; private set; }
        
        public static InventoryManager Inventory { get; private set; }
        public static InputManager Input { get; private set; }
        public static InteractManager Interact { get; private set; }
        
        public static HUDManager HUD { get; private set; }
        
        public static GameOverManager GameOver { get; private set; }
        
        private List<IManager> startSequence;

        [SerializeField] private Light2D globalLight;


        void Awake() {
            Dialogue = GetComponent<DialogueManager>();
            Audio = GetComponent<AudioManager>();
            Inventory = GetComponent<InventoryManager>();
            Input = GetComponent<InputManager>();
            Interact = GetComponent<InteractManager>();
            HUD = GetComponent<HUDManager>();
            GameOver = GetComponent<GameOverManager>();
            
            startSequence = new List<IManager>() {
                Input,
                Dialogue,
                Audio,
                Inventory,
                Interact,
                HUD,
                GameOver
            };
            
            StartCoroutine(StartupManagers());
            globalLight.gameObject.SetActive(false);
        }
        

        private IEnumerator StartupManagers() {
            foreach (var manager in startSequence) {
                manager.Startup();
            }

            yield return null;
            
        }
        
    }
}
