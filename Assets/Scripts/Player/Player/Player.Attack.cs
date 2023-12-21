using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Player : MonoBehaviour
{
    private const int ATTACK_ANIMATION_AMOUNT = 3;

    public KeyCode attackKeyCode;
    public float attackCoolTime = 0.5f;
    public GameObject AttackBox;
    public Slider attackCoolTimeBar = null;

    private float currentAttackCoolTime = 0f;

    private void Attack() {
        // update attack cool time bar
        if (attackCoolTimeBar != null) {
            float coolTimeBarValue = (attackCoolTime - currentAttackCoolTime) / attackCoolTime;
            attackCoolTimeBar.value = coolTimeBarValue;
        }

       if (Input.GetKeyDown(attackKeyCode) && currentAttackCoolTime <= 0) {
            // activateAttackBox
            StartCoroutine(ActivateAttackBox());

            // cool down
            currentAttackCoolTime = attackCoolTime;
            StartCoroutine(CoolDown());

            // animation
            RandomAttackAnimation();

            // attack sound
            PlayRandomAttackSound();
        }
    }

    private IEnumerator ActivateAttackBox() {
        AttackBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        AttackBox.SetActive(false);
    }

    private IEnumerator CoolDown() {
        // cool down
        currentAttackCoolTime = attackCoolTime;
         while (currentAttackCoolTime > 0f) {
            currentAttackCoolTime -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
