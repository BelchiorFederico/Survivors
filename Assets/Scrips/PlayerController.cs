using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    private InputAction movement;
    private void Awake() {
        input = new PlayerInput();        
    }

    private void OnEnable() {
        movement = input.CharacterControls.Movement;
        movement.Enable();
    }

    private void OnDisable() {
        movement.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Movement Values: {movement.ReadValue<Vector2>()}");
    }
}
