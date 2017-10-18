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
            case "AssemblyLinesScene":
                GameObject.Find("Button_AssemblyLines").GetComponent<Button>().interactable = false;

                break;
            case "Extractions":
                GameObject.Find("Button_Extractions").GetComponent<Button>().interactable = false;

                break;
            case "BattleList":
                GameObject.Find("Button_BattleList").GetComponent<Button>().interactable = false;

                break;
            case "RobotInventory":
                GameObject.Find("Button_RobotInventory").GetComponent<Button>().interactable = false;

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

        //Debug.Log("Escena : " + sceneName);
    }

    public void CreateNode(GameObject createNodePanel)
    {
        createNodePanel.SetActive(true);
    }

    public void CancelCreation()
    {
        GameObject.Find("CreateNodePanel").SetActive(false);
    }

}
