using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneManager : MonoBehaviour
{
    public GameObject ReadyCountDownText;

    private Light lightComponent;

    void Start()
    {
        lightComponent = GameObject.FindWithTag("Light").GetComponent<Light>();

        Cursor.visible = false;

        StartCoroutine(ShowReadyScreen());
    }

    private IEnumerator ShowReadyScreen() {

        Time.timeScale = 0f;
        
        lightComponent.intensity = 0.5f;
        ReadyCountDownText.SetActive(true);

        float time = 3f;
        while (time > 0) {
            ReadyCountDownText.GetComponent<ReadyCountDownText>().ChangeTextMessage(time.ToString());
            yield return new WaitForSecondsRealtime(1f);
            time -= 1f;

            Debug.Log(time);
        }

        lightComponent.intensity = 1f;
        ReadyCountDownText.SetActive(false);

        // play
        Time.timeScale = 1f;
    }
}
