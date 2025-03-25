using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Lights {
    public class PlayerDetector: MonoBehaviour {
        private Light2D light2D;

        private void Start() {
            light2D = GetComponent<Light2D>();
        }
        private void Update() {
            var lightRadius = light2D.pointLightOuterRadius;
            Debug.DrawCircle(transform.position, lightRadius, 32, Color.green);
            
            var hits = new List<RaycastHit2D>();
            Physics2D.CircleCast(transform.position, lightRadius, Vector2.zero, new ContactFilter2D().NoFilter(), hits, lightRadius);

            foreach (var hit in hits) {
                if (hit.collider is not null) {
                    var player = hit.collider.gameObject.GetComponent<Player>();
                    if (player) {
                        player.Transform();
                    }
                    UnityEngine.Debug.DrawLine(transform.position, hit.point, Color.red);
                }    
            }
        
        }
    }
}