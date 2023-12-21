using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    public AudioClip[] attackSounds;
    public AudioClip[] hitSounds;

    private AudioSource audioSource;

    public void PlayRandomAttackSound() {
        audioSource.clip = attackSounds[Random.Range(0, attackSounds.Length)];
        audioSource.Play();
    }

    public void PlayRandomHitSound() {
        audioSource.clip = hitSounds[Random.Range(0, hitSounds.Length)];
        audioSource.Play();
    }
}
