using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Inventory;
using Inventory;
using Port;
using UnityEngine;

namespace Managers{
    public class InventoryManager: MonoBehaviour, IManager{
        [SerializeField] private List<UsableItem> inventory = new();

        public ManagerStatus Status { get; set; }

        public void Startup() {
            Status = ManagerStatus.Started;
        }
        
        public void Add(UsableItem item) {
            inventory.Add(item);
        }

        public void Add(List<UsableItem> item) {
            inventory.AddRange(item);
        }

        public List<UsableItem> GetAllOfType(UsableItem.Type type){
            return inventory.FindAll(item => item.type == type);
        }

        public void Use(UsableItem item) {
            inventory[inventory.IndexOf(item)].Use();
            if (inventory[inventory.IndexOf(item)].IsBroken()) {
                inventory.Remove(item);
            }
        }
    }
}