using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneManager : MonoBehaviour
{
    public static LevelOneManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [SerializeField] [Range(0, 4)] int m_Keys = 0;
    [SerializeField] GameObject m_DoorCollider;

    // Start is called before the first frame update
    private void Start() {
        m_DoorCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (m_Keys == 4) {
            m_DoorCollider.SetActive(true);
        }
    }

    public void AddKey() {
        m_Keys++;
    }
}
