using System.Collections.Generic;
using Dialogues;
using Port;
using UnityEngine;

namespace Prison {
    public class CellsWorkflow: MonoBehaviour {
        [SerializeField] private List<GameObject> interactables;
        [SerializeField] private DialogueSequence sequence;
        [SerializeField] private GameObject wall;
        private bool hasInteracted;
        
        private void Start() {
            hasInteracted = false;
            interactables.ForEach(interactable => interactable.GetComponent<Interactable>().Disable());
        }


        private void Update() {
            if (sequence.IsFinished() && !hasInteracted) {
                wall.GetComponent<Interactable>().Enable();
                hasInteracted = true;
            }

            if (hasInteracted) {
                if (wall.GetComponent<Interactable>().CanInteract() == false) {
                    EnableInteraction();
                }
                
            }
        }


        private void EnableInteraction() {
            interactables.ForEach(interactable => interactable.GetComponent<Interactable>().Enable());
        }
    }
}