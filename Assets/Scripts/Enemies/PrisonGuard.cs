using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Enemies {
    public class PrisonGuard: MonoBehaviour {
        public float radius;
        
        private void Update() {
            Debug.DrawCircle(transform.position, radius, 32, Color.green);
            
            var hits = new List<RaycastHit2D>();
            Physics2D.CircleCast(transform.position, radius, Vector2.zero, new ContactFilter2D().NoFilter(), hits, radius);

            foreach (var hit in hits) {
                if (hit.collider is not null) {
                    var player = hit.collider.gameObject.GetComponent<Player>();
                    if (player && !player.IsTransformed()) {
                        GameManagers.GameOver.GameOver("They caught you and ate you!");
                    }
                    UnityEngine.Debug.DrawLine(transform.position, hit.point, Color.red);
                }    
            }
        
        }
    }
}