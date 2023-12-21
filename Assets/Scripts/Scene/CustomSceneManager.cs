using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CustomSceneManager
{
    public static string crossSceneInfo {get; set;}

    public static void ChangeInGameScene() {
        crossSceneInfo = "";
        SceneManager.LoadScene("InGame");
    }

    public static void ChangeResultScene(string defeatPlayer) {
        crossSceneInfo = defeatPlayer;
        SceneManager.LoadScene("Result");
    }
}
