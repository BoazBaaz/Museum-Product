using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneEventOnCollision : MonoBehaviour
{
    [SerializeField] UnityEvent collisionEvent;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            collisionEvent.Invoke();
        }
    }
}
