using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class Player : MonoBehaviour
{
    private Coroutine recentStatusEffectCoroutine;
    private EPlayerStatusEffect recentStatusEffect;

    private float originalWalkSpeed;

    public void GetStatusEffect(EPlayerStatusEffect statusEffect, float duration) {
        if (recentStatusEffectCoroutine != null && recentStatusEffect == statusEffect) { 
            StopCoroutine(recentStatusEffectCoroutine);
        }

        recentStatusEffect = statusEffect;

        switch (statusEffect) {
            case EPlayerStatusEffect.Stagger:
                recentStatusEffectCoroutine = StartCoroutine(StaggerStatusEffect(duration));
                break;
            
            case EPlayerStatusEffect.Slow:
                recentStatusEffectCoroutine = StartCoroutine(SlowStatusEffect(duration));
                break;
        }
    }

    private IEnumerator StaggerStatusEffect(float duration) {
        canMove = false;
        IdleAnimation();

        yield return new WaitForSeconds(duration);

        canMove = true;
    }

    private IEnumerator SlowStatusEffect(float duration) {
        walkSpeed = originalWalkSpeed / 3;

        yield return new WaitForSeconds(duration);

        walkSpeed = originalWalkSpeed;
    }

    private void StatusEffectInit() {
        originalWalkSpeed = walkSpeed;
    }
}
