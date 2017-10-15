using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager> {


    void Start () {

	}
	
	void Update () {
        switch (GameState.Instance.LastScene)
        {
            case "BattleList":

                break;
        }
	}

    public void NavigateScene(string sceneName)
    {
        switch (sceneName)
        {
            case "AssemblyLinesScene": GameState.Instance.LoadScene(sceneName); break;
            case "RobotInventory": GameState.Instance.LoadScene(sceneName); break;
            case "Extractions": GameState.Instance.LoadScene(sceneName); break;
            case "BattleList": GameState.Instance.LoadScene(sceneName); break;
        }

        Debug.Log("Escena : " + sceneName);
    }

}
