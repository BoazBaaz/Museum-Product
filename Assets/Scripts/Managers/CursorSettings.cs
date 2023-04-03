using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSettings : MonoBehaviour {
    public static CursorSettings instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [SerializeField] private bool m_Visable;
    [SerializeField] private bool m_Locked;

    private void Start()
    {
        // Set the cursor for this scene
        Cursor.visible = m_Visable;
        Cursor.visible = false;
        Cursor.lockState = m_Locked ? CursorLockMode.Locked :CursorLockMode.None;
    }

    public void UpdateCursor() {
        // Set the cursor for this scene
        Cursor.visible = m_Visable;
        Cursor.lockState = m_Locked ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
