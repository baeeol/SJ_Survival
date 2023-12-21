using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float duration;

    public IEnumerator Excute() {
        gameObject.SetActive(true);

        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(startPos.x, 0, startPos.z);
        
        float time = 0;
        while (time < duration) {
            // fall
            transform.position = Vector3.Lerp(startPos, endPos, time / duration);
            time += Time.deltaTime;

            yield return null;
        }

        yield return null;
    }
}
