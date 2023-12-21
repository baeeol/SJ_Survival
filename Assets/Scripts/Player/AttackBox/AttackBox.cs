using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public float knockBackStrength = 5f;
    public float knockBackDuration = 0.5f;

    void Start() {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider target) {
        // knock back
        target
            .transform
            .GetComponent<Rigidbody>()
            .AddForce(transform.forward * knockBackStrength * 100f);

        // stagger status effect
        target
            .transform
            .GetComponent<Player>()
            .GetStatusEffect(EPlayerStatusEffect.Stagger,  knockBackDuration);

        // hit sound
        target
            .transform
            .GetComponent<Player>()
            .PlayRandomHitSound();
    }
}
