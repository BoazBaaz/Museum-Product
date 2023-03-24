using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    DefaultInputActions input;
    Rigidbody rb;

    [SerializeField] float m_Speed = 10f;
    
    // Start is called before the first frame update
    void Start() {
        input = new DefaultInputActions();
        input.Enable();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        rb.MovePosition(new Vector3(gameObject.transform.position.x + input.Player.Move.ReadValue<Vector2>().x * m_Speed * Time.deltaTime,
                                    gameObject.transform.position.y,
                                    gameObject.transform.position.z + input.Player.Move.ReadValue<Vector2>().y * m_Speed * Time.deltaTime));
    }
}
