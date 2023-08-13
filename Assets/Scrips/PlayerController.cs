using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float movSpeed;
    Vector2 currentMov;

    PlayerInput input;
    private InputAction movement;

    [SerializeField] Animator animator;
    string currentState;

    //Animation constants

    //Walking
    private const string CHAR_WALK_TOP = "Character_Walk_Top";
    private const string CHAR_WALK_BOTTOM = "Character_Walk_Bottom";
    private const string CHAR_WALK_LEFT = "Character_Walk_Left";
    private const string CHAR_WALK_RIGHT = "Character_Walk_Right";
    private const string CHAR_WALK_TOP_RIGHT = "Character_Walk_Top_Right";
    private const string CHAR_WALK_TOP_LEFT = "Character_Walk_Top_Left";
    private const string CHAR_WALK_BOTTOM_RIGHT = "Character_Walk_Bottom_Right";
    private const string CHAR_WALK_BOTTOM_LEFT = "Character_Walk_Bottom_Left";

    //Idle
    private const string CHAR_IDLE_TOP = "Character_Idle_Top";
    private const string CHAR_IDLE_BOTTOM = "Character_Idle_Bottom";
    private const string CHAR_IDLE_LEFT = "Character_Idle_Left";
    private const string CHAR_IDLE_RIGHT = "Character_Idle_Right";
    private const string CHAR_IDLE_TOP_RIGHT = "Character_Idle_Top_Right";
    private const string CHAR_IDLE_TOP_LEFT = "Character_Idle_Top_Left";
    private const string CHAR_IDLE_BOTTOM_RIGHT = "Character_Idle_Bottom_Right";
    private const string CHAR_IDLE_BOTTOM_LEFT = "Character_Idle_Bottom_Left";


    private void Awake() {
        rb2d = this.GetComponent<Rigidbody2D>();

        input = new PlayerInput();
        currentMov = input.CharacterControls.Movement.ReadValue<Vector2>();
    }

    private void OnEnable() {
        input.Enable();
    }

    private void OnDisable() {
        input.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }

    private void FixedUpdate() {
        Move();
    }

    void Move() {
        currentMov = input.CharacterControls.Movement.ReadValue<Vector2>();
        rb2d.velocity = new Vector2(currentMov.x * movSpeed, currentMov.y * movSpeed);

    }

    private void Animate() {

        if (currentMov.y > 0.125f && currentMov.x < 0.125f && currentMov.x > -0.125f) {
            ChangeAnimation(CHAR_WALK_TOP);
        }

        if (currentMov.y < -0.125f && currentMov.x < 0.125f && currentMov.x > -0.125f) {
            ChangeAnimation(CHAR_WALK_BOTTOM);
        }

        if (currentMov.x > 0.125f && currentMov.y < 0.125f && currentMov.y > -0.125f) {
            ChangeAnimation(CHAR_WALK_RIGHT);
        }

        if (currentMov.x < -0.125f && currentMov.y < 0.125f && currentMov.y > -0.125f) {
            ChangeAnimation(CHAR_WALK_LEFT);
        }

        if (currentMov.x < -0.125f && currentMov.y > 0.125f) {
            ChangeAnimation(CHAR_WALK_TOP_LEFT);
        }

        if (currentMov.x < -0.125f && currentMov.y < -0.125f) {
            ChangeAnimation(CHAR_WALK_BOTTOM_LEFT);
        }

        if (currentMov.x > 0.125f && currentMov.y > 0.125f) {
            ChangeAnimation(CHAR_WALK_TOP_RIGHT);
        }

        if (currentMov.x > 0.125f && currentMov.y < -0.125f) {
            ChangeAnimation(CHAR_WALK_BOTTOM_RIGHT);
        }

        if (currentMov.x < 0.125f && currentMov.x > -0.125f && currentMov.y < 0.125f && currentMov.y > -0.125f) {
            animator.SetBool("isMoving", false);
        }
    }

    private void ChangeAnimation(string newState) {
        
        animator.SetBool("isMoving", true);

        //if (newState == currentState) return;

        animator.Play(newState);

        currentState = newState;
    }
}
