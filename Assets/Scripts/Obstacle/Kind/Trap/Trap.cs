using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float duration;

    public IEnumerator Excute() {
        gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);
    }

    private void OnTriggerEnter(Collider target) {
        Destroy(gameObject);
    }
}
