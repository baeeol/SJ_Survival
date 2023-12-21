using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Log : MonoBehaviour
{
    public float range;
    public float duration;

    public IEnumerator Excute() {
        gameObject.SetActive(true);

        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + (transform.forward * range);
        
        float time = 0;
        while (time < duration) {
            // move forward
            transform.position = Vector3.Lerp(startPos, endPos, time / duration);
            time += Time.deltaTime;

            // spin
            transform.Rotate(2f, 0.0f, 0f);
            yield return null;
        }

        yield return null;
    }
}
