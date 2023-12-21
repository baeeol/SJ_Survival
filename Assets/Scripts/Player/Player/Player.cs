using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Player : MonoBehaviour
{
    void Awake() {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

        randomSpawn();
    }

    private void randomSpawn() {
        Vector3 mapScale = GameObject.FindGameObjectWithTag("Map")
                            .GetComponent<BoxCollider>()
                            .bounds.size;
        
        float rangeX = (mapScale.x / 2f) - 5f;
        float rangeZ = (mapScale.z / 2f) - 5f;

        float spawnX = Random.Range(-rangeX, rangeX);
        float spawnZ = Random.Range(-rangeZ, rangeZ);

        transform.position = new Vector3(spawnX, 0.2f, spawnZ);
    }

    void Start() {
        HealthInit();
        StatusEffectInit();
    }

    void Update() {
        Move();
        Attack();
        HealthEvent();
    }
}