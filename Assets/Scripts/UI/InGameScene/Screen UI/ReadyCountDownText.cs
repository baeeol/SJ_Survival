using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadyCountDownText : MonoBehaviour
{
    public void ChangeTextMessage(string msg) {
        gameObject.GetComponent<TMP_Text>().text = msg;
    }
}
