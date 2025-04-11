using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Lights {
    public class PlayerDetector: MonoBehaviour {
        private Light2D light2D;
        private Player player;

        private void Start() {
            light2D = GetComponent<Light2D>();
        }
        private void Update() {
            var lightRadius = light2D.pointLightOuterRadius;
            Debug.DrawCircle(transform.position, lightRadius, 32, Color.green);
            
            var hits = new List<RaycastHit2D>();
            Physics2D.CircleCast(transform.position, lightRadius, Vector2.zero, new ContactFilter2D().NoFilter(), hits, lightRadius);


            RaycastHit2D hit = hits.Find(hit => hit.collider.gameObject.GetComponent<Player>() != null);

            if (hit) {
                player = hit.collider.gameObject.GetComponent<Player>();
                player.Transform();
            }
            else {
                if (player != null) {
                    player.NotTransform();
                    player = null;
                }
            }
        }
    }
}