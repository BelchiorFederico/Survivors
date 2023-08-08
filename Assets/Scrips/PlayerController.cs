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
        
    }

    private void FixedUpdate() {
        Move();
    }

    void Move() {
        currentMov = input.CharacterControls.Movement.ReadValue<Vector2>();
        rb2d.velocity = new Vector2(currentMov.x * movSpeed, currentMov.y * movSpeed);
    }
}
