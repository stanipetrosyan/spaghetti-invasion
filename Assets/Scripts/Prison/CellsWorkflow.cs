using System.Collections.Generic;
using Port;
using UnityEngine;

namespace Prison {
    public class CellsWorkflow: MonoBehaviour {
        [SerializeField] private List<GameObject> interactables;
        
        private void Start() {
            interactables.ForEach(interactable => interactable.GetComponent<Interactable>().Disable());
        }

        private void Update() {
            
        }

        public void EnableInteraction() {
            interactables.ForEach(interactable => interactable.GetComponent<Interactable>().Enable());
        }
    }
}