using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager> {

    private Game game;
    public Deck ChoosedDeck { get; set; }

    void Start () {
        game = Game.Instance;
	}
	
	void Update () {
        /*switch (game.ActualState)
        {
            case Game.GameState.AssemblyLines:
                GameObject.Find("Button_AssemblyLines").GetComponent<Button>().interactable = false;

                break;
            case "CM_3_Extractions":
                GameObject.Find("Button_Extractions").GetComponent<Button>().interactable = false;

                break;
            case "CM_4_BattleList":
                GameObject.Find("Button_BattleList").GetComponent<Button>().interactable = false;

                break;
            case "CM_2_RobotInventory":
                GameObject.Find("Button_RobotInventory").GetComponent<Button>().interactable = false;
                break;

        }*/
	}

    public void NavigateScene(string sceneName)
    {
        switch (sceneName)
        {
            case "CM_1_AssemblyLines": Game.Instance.LoadScene(sceneName); break;
            case "CM_2_RobotInventory": Game.Instance.LoadScene(sceneName); break;
            case "CM_3_Extractions": Game.Instance.LoadScene(sceneName); break;
            case "CM_4_BattleList": Game.Instance.LoadScene(sceneName); break;
            case "CM_4.1_BattlePreparation": Game.Instance.LoadScene(sceneName); break;
            case "CM_4.2_Minigame": Game.Instance.LoadScene(sceneName); break;
        }

        Debug.Log("Escena : " + sceneName);
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


