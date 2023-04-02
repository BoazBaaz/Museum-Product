using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepDestroy : MonoBehaviour
{
    private float lifetime;

    public void LifeTime(float _time) {
        lifetime = _time;
        StartCoroutine(Life());
    }

    IEnumerator Life() {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
