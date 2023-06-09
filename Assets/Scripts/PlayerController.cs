using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private enum LastStep {
        left = 0,
        right = 1
    };

    private DefaultInputActions input;

    private Vector2 moveInput;
    private Vector2 lookInput;

    [Header("Input")]
    [SerializeField] private float m_MoveSpeed = 10f;
    [SerializeField] private Vector2 m_MouseSensitivity = new Vector2(10.0f, 10.0f);
    [SerializeField] private Vector2 m_MouseClamp = new Vector2(310.0f, 50.0f);

    [Header("Footsteps")]

    [SerializeField] private GameObject m_StepLPrefab;
    [SerializeField] private GameObject m_StepRPrefab;
    [SerializeField] private Transform m_StepLTransform;
    [SerializeField] private Transform m_StepRTransform;
    [SerializeField] private float m_StepLife = 5.0f;
    [SerializeField] private float m_StepDistance = 2.0f;
    [SerializeField] private Vector3 m_LastStepPoint;
    [SerializeField] private LastStep m_LastStep = LastStep.left;

    private void Start() {
        // Enable the player input
        input = new DefaultInputActions();
        input.Enable();

        // Set the lastStepPoint to the current player position
        m_LastStepPoint = transform.position;
    }

    private void Update() {
        // Get the current rotation of the player and camera
        Vector3 playerRotation = transform.localEulerAngles;
        Vector3 camRotation = Camera.main.transform.localEulerAngles;

        // Calculate the new rotation of the player and camera
        playerRotation.y += lookInput.x * m_MouseSensitivity.x * Time.deltaTime;
        camRotation.x -= lookInput.y * m_MouseSensitivity.y * Time.deltaTime;

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

        // Check if the distance between the lastStepPoint and the player is larger the the stepDistance
        if (Vector3.Distance(m_LastStepPoint, transform.position) >= m_StepDistance) {
            // Check what the last placed footstep was
            if (m_LastStep ==  LastStep.left) {
                // Create the footstep, and give the stepLife value to the stepDestroy script
                GameObject stepObject = Instantiate(m_StepRPrefab, m_StepRTransform.position, transform.rotation);
                stepObject.GetComponent<StepDestroy>().LifeTime(m_StepLife);

                m_LastStep = LastStep.right;
            } else if (m_LastStep == LastStep.right) {
                // Create the footstep, and give the stepLife value to the stepDestroy script
                GameObject stepObject = Instantiate(m_StepLPrefab, m_StepLTransform.position, transform.rotation);
                stepObject.GetComponent<StepDestroy>().LifeTime(m_StepLife);

                m_LastStep = LastStep.left;
            }

            // Set a new lastStepPoint
            m_LastStepPoint = transform.position;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="callbackContent"></param>
    public void Move(InputAction.CallbackContext callbackContent) {
        moveInput = callbackContent.ReadValue<Vector2>();
    }

    /// <remark>
    /// This function updates the lookInput variable only when the event is called for the coresponding key presses.
    /// </remark>
    /// <list type="events">
    /// <item>callBackContent</item>
    /// </list>
    /// <code>lookInput = callbackContent.ReadValue<Vector2>();</code>
    /// <example>Look(InputAction.Look.CallbackContent())</example>
    public void Look(InputAction.CallbackContext callbackContent) {
        lookInput = callbackContent.ReadValue<Vector2>();
    }
}
