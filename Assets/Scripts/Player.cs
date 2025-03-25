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
        transformed = true;
    }

    private void Update() {
        ManageAnxiety();

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
                    GameManagers.Interact.Activate();

                    // TODO: use sendMessage instead of get component ? 
                    if (Input.GetKeyDown(KeyCode.E)) {
                        hit.collider.gameObject.GetComponent<Interactable>().Interact();
                    }

                    break;
                case "Dialogue":
                    GameManagers.Interact.Activate();
                    if (Input.GetKeyDown(KeyCode.E)) {
                        hit.collider.gameObject.GetComponent<DialogueTrigger>().StartDialogue();
                    }

                    break;
                default:
                    break;
            }
        }
        else {
            GameManagers.Interact.Deactivate();
        }
    }

    private void ManageAnxiety() {
        if (transformed) anxietyCounter.IncreaseAnxiety(0.5f);
        else anxietyCounter.DecreaseAnxiety(0.5f);
    }

    private void Move() {
        transformed = false;

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