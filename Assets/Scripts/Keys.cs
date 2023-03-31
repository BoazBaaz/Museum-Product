using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    [SerializeField] Sprite spriteKeyFull;
    [SerializeField] Image img;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerController>().AddKey();
            img.sprite = spriteKeyFull;
            Destroy(this.gameObject);
        }
    }
}
