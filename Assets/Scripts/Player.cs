using Dialogues;
using Managers;
using Port;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float radius = 0.5f;
    private Vector2 direction = Vector2.zero;

    [SerializeField] private LayerMask interactableLayer;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool transformed = false;
    private AnxietyCounter anxietyCounter;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        anxietyCounter = GetComponent<AnxietyCounter>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Transform() {
        spriteRenderer.color = Color.blue;
        transformed = true;
        anxietyCounter.anxiety += (Time.deltaTime * 0.5f);
    }

    private void Update() {
        if (GameManagers.Input.CanMove()) {
            Move();
            DetectCollision();
        }
    }

    private void DetectCollision() {
        var hit = Physics2D.CircleCast(transform.position + new Vector3(direction.x, direction.y, 0), radius,
            Vector2.up, radius, interactableLayer);
        Debug.DrawCircle(rb.position + direction, radius, 1000, Color.green);

        if (hit.collider is not null) {
            UnityEngine.Debug.DrawLine(transform.position, hit.point, Color.red);
            switch (LayerMask.LayerToName(hit.collider.gameObject.layer)) {
                case "Light":
                    break;
                case "Interactable":
                    //GameManagers.Interact.Activate();
                    
                    // TODO: use sendMessage instead of get component ? 
                    if (Input.GetKeyDown(KeyCode.E)) {
                        hit.collider.gameObject.GetComponent<Port.Interactable>().Interact();
                    }

                    break;
                case "Dialogue":
                    hit.collider.gameObject.GetComponent<DialogueTrigger>().StartDialogue();
                    break;
                default:
                    break;
            }
        }
        else {
            //GameManagers.Interact.Deactivate();
        }
    }

    private void Move() {
        transformed = false;
        spriteRenderer.color = transformed ? Color.blue : Color.white;

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        if (moveHorizontal != 0) {
            direction = new Vector2(moveHorizontal, 0) * 2;
        }
        else if (moveVertical != 0) {
            direction = new Vector2(0, moveVertical) * 2;
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;

        rb.velocity = movement;
    }
}