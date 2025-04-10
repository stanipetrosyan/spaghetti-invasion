using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Enemies {
    public class PrisonGuard : MonoBehaviour {
        private Light2D light2D;
        private float radius;
        public bool patrol = false;
        private bool canMove;
        private int moveLimit = 15;
        private Vector3 initialPosition;
        private int changeX = 1;
        private int changeY = 1;
        private int speed = 6;
        [SerializeField] private LayerMask interactableLayer;
        private Animator animator;

        private void Start() {
            light2D = GetComponent<Light2D>();
            radius = light2D.pointLightOuterRadius;
            initialPosition = gameObject.transform.position;
            animator = GetComponent<Animator>();
            
            if (patrol) {
                canMove = true;
            }
        }

        private void Update() {
            if (canMove) {
                Patrol();
            }


            Debug.DrawCircle(transform.position, radius, 32, Color.green);

            var contactFilter = new ContactFilter2D {
                layerMask = interactableLayer
            };
            var hits = new List<RaycastHit2D>();
            Physics2D.CircleCast(transform.position, radius, Vector2.zero, contactFilter, hits,
                radius);
            
            foreach (var hit in hits) {
                if (patrol) {
                    canMove = true;
                }
                
                if (hit.collider is not null) {
                    var player = hit.collider.gameObject.GetComponent<Player>();
                    if (player) {
                        if (patrol) {
                            canMove = false;
                        }

                        if (!player.IsTransformed()) {
                            // player.GameOver(Reason.Guard);

                            //Debug.Log(!player.IsTransformed());
                        }
                    }
                }
            }
        }

        private void Patrol() {
            var position = gameObject.transform.position;
            // down
            if (position.y - initialPosition.y >= 0 && position.y - initialPosition.y <= 0.1f &&
                position.x - initialPosition.x >= 0 && position.x - initialPosition.x <= 0.1f) {
                changeY = 1;
                changeX = 0;
                animator.SetInteger("Move", 0);
            }
            //right
            else if (initialPosition.y - position.y >= moveLimit && position.x - initialPosition.x <= moveLimit) {
                changeY = 0;
                changeX = 1;
                animator.SetInteger("Move", 1);
            }
            //left
            else if (position.x - initialPosition.x >= moveLimit && initialPosition.y - position.y >= 0.1) {
                changeX = 0;
                changeY = -1;
                animator.SetInteger("Move", 2);
            }
            // up
            else if (position.y - initialPosition.y >= 0 && position.y - initialPosition.y <= 0.1f) {
                changeY = 0;
                changeX = -1;
                animator.SetInteger("Move", 4);
            }

            gameObject.transform.position += Vector3.down * (Time.deltaTime * changeY * speed);
            gameObject.transform.position += Vector3.right * (Time.deltaTime * changeX * speed);
        }
    }
}