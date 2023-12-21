using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSceneManager : MonoBehaviour
{
    private string victoryPlayer;

    private Animator knightAnimator;
    private Animator solarAnimator;

    private GameObject spotLight;

    private void Start() {
        victoryPlayer = 
            CustomSceneManager.crossSceneInfo == "Knight" ? "Solar" : "Knight";

        knightAnimator = GameObject.Find("Knight").GetComponent<Animator>();
        solarAnimator = GameObject.Find("Solar").GetComponent<Animator>();

        spotLight = GameObject.FindWithTag("Light");

        SetPlayerResultAnimation();
        SetSpotLight();
    }

    private void Update() {
        if (Input.GetKeyDown("return")) {
            Debug.Log("sdfs");
            ReStartGame();
        }
    }

    private void SetPlayerResultAnimation() {
        knightAnimator.SetTrigger("isEndGame");
        solarAnimator.SetTrigger("isEndGame");

        if (victoryPlayer == "Knight") {
            knightAnimator.SetBool("isVictory", true);
            solarAnimator.SetBool("isVictory", false);
        } else {
            knightAnimator.SetBool("isVictory", false);
            solarAnimator.SetBool("isVictory", true);
        }
    }

    private void SetSpotLight() {
        if (victoryPlayer == "Knight") {
            spotLight.transform.position = new Vector3(-1.65f, 4.51f, -32.02f);
            spotLight.transform.rotation = Quaternion.Euler(new Vector3(65.7f, -10.8f, 0));
        } else {
            spotLight.transform.position = new Vector3(2.41f, 4.51f, -32.25f);
            spotLight.transform.rotation = Quaternion.Euler(new Vector3(65.7f, -10.8f, 0));
        }
    }

    private void ReStartGame() {
        CustomSceneManager.ChangeInGameScene();
    }
}
