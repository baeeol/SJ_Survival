using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    private Animator animator;

    private void MovingAnimation() {
        animator.SetBool("isMove", true);
    }

    private void RandomAttackAnimation() {
        animator.SetTrigger("doAttack");

        int randomAnimationNumber = Random.Range(0, ATTACK_ANIMATION_AMOUNT);
        animator.SetInteger("attackType", randomAnimationNumber);
    }

    private void IdleAnimation() {
        animator.SetBool("isMove", false);
    }
}
