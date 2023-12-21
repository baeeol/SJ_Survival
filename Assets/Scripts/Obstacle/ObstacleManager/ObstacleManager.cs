using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    protected void SetRandomPlayerPosition() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject randomPlayer = players[Random.Range(0, players.Length)];
        
        transform.position = randomPlayer.transform.position;
    }

    protected void SetRandomRotation(bool x, bool y, bool z) {
        float rotationX = (x) ? Random.Range(0f, 360f) : transform.rotation.x;
        float rotationY = (y) ? Random.Range(0f, 360f) : transform.rotation.y;
        float rotationZ = (z) ? Random.Range(0f, 360f) : transform.rotation.z;

        transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
    }
}
