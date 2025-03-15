using UnityEngine;

namespace DefaultNamespace.Inventory
{
    [System.Serializable]
    public class Key: Item{
        [SerializeField] private string type = "Chiave generica";
    }
}