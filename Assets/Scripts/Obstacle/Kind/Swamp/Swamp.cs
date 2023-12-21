using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamp : MonoBehaviour
{
    public float duration;

    public IEnumerator Excute() {
        gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);
    }
}
