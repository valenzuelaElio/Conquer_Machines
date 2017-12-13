using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScenesManager{

    static string[] SceneList;
    public static string LastLoadedScene;
    public static string PreviousScene;

    public static void GoToScene(string SceneName)
    {
        foreach (string sceneName in SceneList)
        {
            if (sceneName == SceneName)
            {
                Game.GameInstance.ActualState = Game.GameState.Loading;
                //Debug.Log("Antes de Cargar");
                SceneManager.LoadScene(SceneName);
                //Debug.Log("Despues de Cargar");
                //Game.Instance.ActualState = Game.GameState.Playing;

            }
        }
        PreviousScene = LastLoadedScene;
        LastLoadedScene = SceneName;
        DataManager.Save();
        //Debug.Log("LastScene = " + LastLoadedScene);
    }

    public static void RestartScene()
    {
        GoToScene(LastLoadedScene);
    }

    public static void LoadScenes(string[] sceneNames)
    {
        SceneList = new string[sceneNames.Length];
        for (int i = 0; i < sceneNames.Length; i++)
        {
            SceneList[i] = sceneNames[i];
        }
    }

}
