using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager> {

	void Start () {
		
	}
	
	void Update () {
		
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
