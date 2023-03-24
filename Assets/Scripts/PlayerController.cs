using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    DefaultInputActions input;  
    
    // Start is called before the first frame update
    void Start() {
        input = new DefaultInputActions();
        input.Enable();
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(input.Player.Move.ReadValue<Vector2>());
    }
}
