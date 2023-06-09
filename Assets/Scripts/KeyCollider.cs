using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollider : MonoBehaviour
{
    [SerializeField] Sprite spriteKeyFull;
    [SerializeField] Image img;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            FindObjectOfType<WhiteRoomManager>().AddKey();
            img.sprite = spriteKeyFull;
            Destroy(this.gameObject);
        }
    }
}
