using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdControlObstacle : MonoBehaviour
{
    public EPlayerStatusEffect statusEffect;
    public float duration;

    private void OnTriggerStay(Collider target) {
        if (target.transform.tag == "Player") {
            // crowd ccontrol
            target.transform.GetComponent<Player>().GetStatusEffect(statusEffect, duration);
        }
    }
}
