using System.Collections.Generic;
using DefaultNamespace.Inventory;
using Port;
using UnityEngine;

namespace DefaultNamespace{
    public class ObjectWithItem : MonoBehaviour, Interactable{
        [SerializeField] private List<UsableItem> items = new();

        public void Interact() {
            Managers.GameManagers.Inventory.Add(items);
            Debug.Log("Added " + items.Count + " items");
        }
    }
}