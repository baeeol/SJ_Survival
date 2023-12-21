using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAttackRange : MonoBehaviour
{
    public float scaleX;
    public float scaleZ;
    public float duration = 1f;

    public IEnumerator Excute() {
        gameObject.SetActive(true);

        Vector3 localScale = transform.localScale;

        float time = 0;
        while (time < duration) {
            float augmentationOfScaleX = Mathf.Lerp(0f, scaleX, time / duration);
            float augmentationOfScaleZ = Mathf.Lerp(0f, scaleZ, time / duration);
            transform.localScale = 
            new Vector3(augmentationOfScaleX, localScale.y, augmentationOfScaleZ);

            time += Time.deltaTime;

            yield return null;
        }

        transform.localScale = localScale;

        gameObject.SetActive(false);

        yield return null;
    }
}
