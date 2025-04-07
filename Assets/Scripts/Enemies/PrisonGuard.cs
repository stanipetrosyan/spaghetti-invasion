using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Enemies {
    public class PrisonGuard: MonoBehaviour {
        private Light2D light2D;
        private float radius;


        private void Start() {
            light2D = GetComponent<Light2D>();
            radius = light2D.pointLightOuterRadius;
        }
        private void Update() {
            Debug.DrawCircle(transform.position, radius, 32, Color.green);
            
            var hits = new List<RaycastHit2D>();
            Physics2D.CircleCast(transform.position, radius, Vector2.zero, new ContactFilter2D().NoFilter(), hits, radius);

            foreach (var hit in hits) {
                if (hit.collider is not null) {
                    var player = hit.collider.gameObject.GetComponent<Player>();
                    if (player && !player.IsTransformed()) {
                        player.GameOver(Reason.Guard);
                    }
                    UnityEngine.Debug.DrawLine(transform.position, hit.point, Color.red);
                }    
            }
        
        }
    }
}