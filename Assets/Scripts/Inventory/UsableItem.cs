using UnityEngine;

namespace Inventory{
    
    [CreateAssetMenu(fileName = "UsableItem", menuName = "ScriptableObjects/UsableItem")]
    public class UsableItem: ScriptableObject{
        public int uses = 1;
        public string displayName;
        public Type type;
        
        public void Use() {}

        public bool IsBroken() {
            return uses == 0;
        }
        
        public enum Type {
            KEY, SHARP, ALTAR_KEY
        }
    }
}