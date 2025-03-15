using Inventory;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace.Inventory
{
    [System.Serializable]
    public abstract class Item : MonoBehaviour{
        [SerializeField] private UsableItem usableItem;

        public void Use() {
            usableItem.uses--;
        }

        public bool IsBroken() {
            return usableItem.uses == 0;
        }
    }
}