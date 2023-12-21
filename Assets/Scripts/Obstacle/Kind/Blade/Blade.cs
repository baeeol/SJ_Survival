using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float duration;

    public IEnumerator Excute() {
        gameObject.SetActive(true);

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(new Vector3(-89f, startRotation.eulerAngles.y, startRotation.eulerAngles.z));

        float time = 0;
        while (time < duration) {
            // swing
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, time / duration);

            time += Time.deltaTime;

            yield return null;
        }

        yield return null;
    }
}
