using System;
using Port;
using UnityEngine;

namespace DefaultNamespace
{
    public class Door : MonoBehaviour, Interactable
    {
        
        bool activated = false;
        public void Interact()
        {
            activated = !activated;
            if(activated) Debug.Log("Door is activated"); else Debug.Log("Door is de-activated");
        }

        private void FixedUpdate()
        {
            if (activated)
            {
                transform.parent.gameObject.SetActive(false);
                Debug.DrawCircle(transform.parent.position, .5f, 1000, Color.green);
            }
        }
    }
}