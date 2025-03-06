using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Lights {
    public class PlayerDetector: MonoBehaviour {
        [SerializeField] private Light2D light2D;

        private void Update() {
        
            Debug.DrawCircle(transform.position, light2D.pointLightOuterRadius, 32, Color.green);
            var vectorDown =  transform.position - new Vector3(0, light2D.pointLightOuterRadius, 0);
            UnityEngine.Debug.DrawLine(transform.position, vectorDown, Color.blue);
            //Debug.DrawLine(vectorDown, , Color.blue);
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            Physics2D.CircleCast(transform.position, light2D.pointLightOuterRadius, Vector2.up, new ContactFilter2D().NoFilter(), hits);

            foreach (var hit in hits) {
                if (hit.collider != null) {
                    UnityEngine.Debug.DrawLine(transform.position, hit.point, Color.red);
                }    
            }
        
        }
    }
}