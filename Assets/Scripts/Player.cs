using Domain;
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
    private Animator animator;

    private float moveHorizontal;
    private float moveVertical;

    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        anxietyCounter = GetComponent<AnxietyCounter>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Transform() {
        transformed = true;
        //animator.SetBool("IsAlien", false);
    }

    public void TransformIntoAlien() {
        transformed = false;
    }

    public bool IsTransformed() {
        return transformed;
    }

    private void Update() {
        ManageAnxiety();

        if (GameManagers.Input.CanMove()) {
            Move();
            DetectCollision();
        }
        else {
            moveHorizontal = 0;
            moveVertical = 0;
            rb.velocity = Vector2.zero;
        }
    }

    private void DetectCollision() {
        var hit = Physics2D.CircleCast(transform.position + new Vector3(direction.x, direction.y, 0), radius,
            Vector2.up, radius, interactableLayer);
        Debug.DrawCircle(rb.position + direction, radius, 1000, Color.green);

        if (hit.collider is not null) {
            UnityEngine.Debug.DrawLine(transform.position, hit.point, Color.red);
            switch (LayerMask.LayerToName(hit.collider.gameObject.layer)) {
                case "Interactable":
                    if (hit.collider.gameObject.GetComponent<Interactable>().CanInteract()) {
                        GameManagers.Interact.Activate();
                        if (Input.GetKeyDown(KeyCode.E)) {
                            hit.collider.gameObject.GetComponent<Interactable>().Interact();
                        }
                    }
                    break;
                case "Graveyard": 
                    hit.collider.gameObject.GetComponent<Workflow>().Trigger();
                    break;
                default:
                    GameManagers.Interact.Deactivate();
                    break;
            }
        }
        else {
            GameManagers.Interact.Deactivate();
        }
    }
    
    public void MaximizeAnxiety() {
        anxietyCounter.SetAnxiety(24f);
        GameManagers.Audio.PlayDeath();
    }
    
    public void MinimizeAnxiety() {
        anxietyCounter.SetAnxiety(15f);
        GameManagers.Audio.StopDeath();
    }

    private void ManageAnxiety() {
        if (transformed) anxietyCounter.IncreaseAnxiety(0.5f);
        else anxietyCounter.DecreaseAnxiety(1.5f);
    }

    private void Move() {

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;
        rb.velocity = movement;
        int animationDirection = 0;
        if (moveVertical < 0)
            animationDirection = 0; 
        else if (moveVertical > 0)
            animationDirection = 1; 
        else if (moveHorizontal < 0)
            animationDirection = 2; 
        else if (moveHorizontal > 0)
            animationDirection = 3; 
        
        
        UnityEngine.Debug.Log("Direction: " + animationDirection + " Movement: " + movement != Vector2.zero + " Alien: " + !transformed);
        
        Animate(animationDirection, movement != Vector2.zero, !transformed);
        transformed = false;
    }

    public void GameOver(Reason reason) {
        GameManagers.GameOver.GameOver(reason);
    }
    

    public void Animate(int animationDirection, bool isMoving, bool isAlien) {
        string state = "Gennaro";
        if (isAlien) {
            state += "Alien";
        }
        else {
            state += "Human";
        }
        switch (animationDirection) {
            case 0:
                state += "Down";
                break;
            case 1:
                state += "Up";
                break;
            case 2:
                state += "Left";
                break;
            case 3:
                state += "Right";
                break;
        }
        if (isMoving) {
            state += "Moving";
        }
        else {
            state += "Idle";
        }
        
        UnityEngine.Debug.Log(state);
        animator.Play(state);
    }
}