using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Player : MonoBehaviour
{
    public int fullHP = 2;
    public Slider HPBar = null;
    public float unbeatableTime = 3f;

    private int HP = 1;

    private void HealthInit() {
        HP = fullHP;
    }

    private void HealthEvent() {
        // update HP bar
        if (HPBar != null) {
            float HPBarValue = (float) HP / (float) fullHP;
            HPBar.value = HPBarValue;
        }

        // checking die
        if (HP <= 0) {
            CustomSceneManager.ChangeResultScene(gameObject.name);
        }
    }

    public void Hit(int damage) {
        PlayRandomHitSound();

        HP -= damage;
        StartCoroutine(UnbeatableState());
    }

    private IEnumerator UnbeatableState() {
        // blink character
        StartCoroutine(BlinkBody());

        // change layer
        int unbeatablePlayerLayer = LayerMask.NameToLayer("UnbeatablePlayer");
        transform.gameObject.layer = unbeatablePlayerLayer;

        // chnage meterial color alpha
        SetColor(0.4f, 0.4f, 0.4f);
        
        yield return new WaitForSeconds(unbeatableTime);

         // change layer
        int playerLayer = LayerMask.NameToLayer("Player");
        transform.gameObject.layer = playerLayer;

         // chnage meterial color alpha
        SetColor(1f, 1f, 1f);
    }

    private IEnumerator BlinkBody() {
        float time = 0f;
        const float blinkTime = 0.2f;
        bool isShow = true;

        while (time < unbeatableTime) {
            transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = isShow;
            isShow = !isShow;
            yield return new WaitForSeconds(blinkTime);
            time += blinkTime;
        }

        transform.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
    }

    private void SetColor(float r, float g, float b) {
        transform
            .GetComponentInChildren<SkinnedMeshRenderer>()
            .material
            .SetColor("_Color", new Color(r, g, b, 1f));
    }
}
