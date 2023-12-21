using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider target) {
        if (target.transform.tag == "Player") {
            // attack player
            target.transform.GetComponent<Player>().Hit(1);
        }
    }
}
