using System.Collections.Generic;
using Port;
using UnityEngine;

namespace Managers
{
    public class InventoryManager : MonoBehaviour, IManager
    {
        private List<Objects> inventory = new();
        
        public ManagerStatus Status { get; set; }
        public void Startup()
        {
            Status = ManagerStatus.Started;
        }


        public void Add(Objects obj)
        {
            inventory.Add(obj);
        }

        public void Remove(Objects obj)
        {
            inventory.Remove(obj);
        }
    }




    public enum Objects
    {
        KEYS
    }
}