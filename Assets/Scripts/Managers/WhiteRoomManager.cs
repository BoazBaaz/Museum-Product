using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WhiteRoomManager : MonoBehaviour
{
    public static WhiteRoomManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [SerializeField] [Range(0, 4)] private int m_Keys = 0;
    [SerializeField] TextMeshProUGUI m_TopText;
    [SerializeField] private GameObject m_DoorCollider;

    // Start is called before the first frame update
    private void Start() {
        m_DoorCollider.SetActive(false);
    }

    // Update is called once per frame
    private void Update() {
        if (m_Keys == 4) {
            m_DoorCollider.SetActive(true);
        }
    }

    public void AddKey() {
        m_Keys++;
        if (m_Keys == 4)  {
            m_TopText.SetText("Leave the room.");
        } else if (m_Keys < 4) {
            m_TopText.SetText("Keys found: {0}/4", m_Keys);
        }
    }
}
