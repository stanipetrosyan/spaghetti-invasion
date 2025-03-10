using System.Collections.Generic;
using Port;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float radius = 2f;
    private Vector2 direction = Vector2.zero;

    [SerializeField] private LayerMask interactableLayer;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool transformed = false;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Transform() {
        spriteRenderer.color = Color.blue;
        transformed = true;
    }

    private void FixedUpdate() {
        transformed = false;
        spriteRenderer.color = transformed ? Color.blue : Color.white;

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        if (moveHorizontal != 0) {
            direction = new Vector2(moveHorizontal, 0);
        }
        else if (moveVertical != 0) {
            direction = new Vector2(0, moveVertical);
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;

        rb.velocity = movement;
        var hit = Physics2D.CircleCast(transform.position, radius, Vector2.up, radius, interactableLayer);
        
        if (hit.collider != null) {
            Debug.Log(hit.collider.gameObject.name);
            UnityEngine.Debug.DrawLine(transform.position, hit.point, Color.red);
            switch (LayerMask.LayerToName(hit.collider.gameObject.layer)) {
                case "Light":
                    break;
                case "Interactable":
                    hit.collider.gameObject.GetComponent<Interactable>().Interact();
                    break;
                default:
                    break;
            }
        }
    }
}