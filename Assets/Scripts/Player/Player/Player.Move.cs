using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerMoveKeyType {
        player1,
        player2,
}

public partial class Player : MonoBehaviour
{
    public EPlayerMoveKeyType moveKeyType;
    public float walkSpeed = 8.0f;

    private bool canMove = true;

    private void Move()
    {
        if (canMove) {
            float hAxis = moveKeyType == EPlayerMoveKeyType.player1 
                ? Input.GetAxisRaw("Player1 Horizontal") 
                : Input.GetAxisRaw("Player2 Horizontal");
            float vAxis = moveKeyType == EPlayerMoveKeyType.player1 
                ? Input.GetAxisRaw("Player1 Vertical") 
                : Input.GetAxisRaw("Player2 Vertical");

            // movement
            Vector3 moveVec = new Vector3(hAxis, 0, vAxis).normalized;
            transform.position += moveVec * walkSpeed * Time.deltaTime;
            
            // animation
            if (moveVec == Vector3.zero) {
                IdleAnimation();
            } else {
                MovingAnimation();
            }
            
            // looking direction
            transform.LookAt(transform.position + moveVec);
        }

        PreventLeaveMap();
    }

    private void PreventLeaveMap() {
        Vector3 mapScale = GameObject.FindGameObjectWithTag("Map")
                            .GetComponent<BoxCollider>()
                            .bounds.size;
        float rangeToBoundary = mapScale.x / 2 - 1f;
        Vector3 currentPos = transform.position;

        if (currentPos.x >= rangeToBoundary) {
            transform.position += new Vector3(-1, 0, 0) * walkSpeed * Time.deltaTime;   
        }

        if (currentPos.x < -rangeToBoundary) {
            transform.position += new Vector3(1, 0, 0) * walkSpeed * Time.deltaTime;   
        }

        if (currentPos.z >= rangeToBoundary) {
            transform.position += new Vector3(0, 0, -1) * walkSpeed * Time.deltaTime;   
        }

        if (currentPos.z < -rangeToBoundary) {
            transform.position += new Vector3(0, 0, 1) * walkSpeed * Time.deltaTime;   
        }
    }
}