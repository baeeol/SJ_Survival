using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 

public class StraightAttackRange : MonoBehaviour
{
    public float Range;
    public float duration = 1f;

    public IEnumerator Excute() {
        gameObject.SetActive(true);

        Vector3 localScale = transform.localScale;
        Vector3 localPosition = transform.localPosition;

        float time = 0;
        while (time < duration) {
            float varianceOfPositionZ = Mathf.Lerp(localPosition.z - (Range / 2), localPosition.z, time / duration);
            transform.localPosition = 
            new Vector3(localPosition.x, localPosition.y, varianceOfPositionZ);

            float augmentationOfScaleZ = Mathf.Lerp(0f, Range, time / duration);
            transform.localScale = 
            new Vector3(localScale.x,localScale.y, augmentationOfScaleZ);

            time += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = localPosition;
        transform.localScale = localScale;

        gameObject.SetActive(false);

        yield return null;
    }
}
