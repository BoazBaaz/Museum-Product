using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    DefaultInputActions input;
    Rigidbody rb;

    [SerializeField] float m_MoveSpeed = 10f;
    [SerializeField] Vector2 m_MouseSensitivity = new Vector2(10.0f, 10.0f);
    [SerializeField] Vector2 m_MouseClampY = new Vector2(-80.0f, 50.0f);
    [SerializeField] [Range(0, 4)] int m_Keys = 0;
    
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
        // Get the current position and rotation of the player and camera
        Vector3 playerPosition = gameObject.transform.position;
        Vector3 playerRotation = gameObject.transform.localEulerAngles;
        Vector3 camRotation = Camera.main.transform.localEulerAngles;

        // Calculate the new  player position
        playerPosition.x += input.Player.Move.ReadValue<Vector2>().x * m_MoveSpeed * Time.deltaTime;
        playerPosition.z += input.Player.Move.ReadValue<Vector2>().y * m_MoveSpeed * Time.deltaTime;

        // Calculate the new player and camera rotation
        playerRotation.y += input.Player.Look.ReadValue<Vector2>().x * m_MouseSensitivity.x * Time.deltaTime;
        camRotation.x -= input.Player.Look.ReadValue<Vector2>().y * m_MouseSensitivity.y * Time.deltaTime;
        //camRotation.x = Mathf.Clamp(camRotation.x, m_MouseClampY[0], m_MouseClampY[1]);

        // Update the position and rotation of the player and the camera
        rb.MovePosition(playerPosition);
        rb.MoveRotation(Quaternion.Euler(playerRotation));
        Camera.main.transform.localRotation = Quaternion.Euler(camRotation);
    }

    public void AddKey() {
        m_Keys++;
    }
}
