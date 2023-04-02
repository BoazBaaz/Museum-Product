using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private DefaultInputActions input;

    [SerializeField] private float m_MoveSpeed = 10f;
    [SerializeField] private Vector2 m_MouseSensitivity = new Vector2(10.0f, 10.0f);
    [SerializeField] private Vector2 m_MouseClamp = new Vector2(310.0f, 50.0f);
    [SerializeField] private GameObject m_FootStepLSprite, m_FootStepRSprite;

    private Vector2 moveInput;
    private Vector2 lookInput;

    // Start is called before the first frame update
    private void Start() {
        input = new DefaultInputActions();
        input.Enable();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update() {
        // Get the current rotation of the player and camera
        Vector3 playerRotation = transform.localEulerAngles;
        Vector3 camRotation = Camera.main.transform.localEulerAngles;

        // Calculate the new rotation of the player and camera
        playerRotation.y += lookInput.x * m_MouseSensitivity.x * Time.deltaTime;
        camRotation.x -= lookInput.y * m_MouseSensitivity.y * Time.deltaTime;

        Debug.Log(camRotation);
        // Clamp the camera rotation
        if (camRotation.x > 180.0f) {
            camRotation.x = Mathf.Max(camRotation.x, m_MouseClamp[0]);
        } else {
            camRotation.x = Mathf.Min(camRotation.x, m_MouseClamp[1]);
        }

        // Update the rotation of the player and camera
        transform.localEulerAngles = playerRotation;
        Camera.main.transform.localEulerAngles = camRotation;

        // Update the player position
        transform.Translate(new Vector3(moveInput.x * m_MoveSpeed * Time.deltaTime, 0.0f, moveInput.y * m_MoveSpeed * Time.deltaTime));
    }

    public void Move(InputAction.CallbackContext callbackContent) {
        moveInput = callbackContent.ReadValue<Vector2>();
    }

    public void Look(InputAction.CallbackContext callbackContent) {
        lookInput = callbackContent.ReadValue<Vector2>();
    }
}
