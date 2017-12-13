using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingleton<GameManager> {

    public DataMision CurrentSelectedMission; //Para pasar la informacion a la escena de batalla;
    public DataAssemblyLine currentAssemblyLineSelected;
    public DataNode currentNodeSelected;

    private Game game;
    public Deck ChoosedDeck { get; set; }

    GameObject SNPanel;//Selected node
    GameObject CNPanel;//Create new Node

    void Start () {
        game = Game.GameInstance;
    }
	
	void Update () {
        if (game.ActualState == Game.GameState.Loading)
        {
            if (ScenesManager.PreviousScene != SceneManager.GetActiveScene().name) //Si se cambio de escena
            {
                //InitializeAssembliLine();
            }

            game.ActualState = Game.GameState.Playing;
        }

        //Updates:
        //UpdateAssemblyLineScene();

    }

    private void UpdateAssemblyLineScene()
    {
        //GameObject SNPanel = GameObject.Find("SelectedNode") as GameObject;
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<AssemblyLine>() != null)
            {
                SNPanel.SetActive(true);
            }
            else
            {
                SNPanel.SetActive(false);
            }

            if (EventSystem.current.currentSelectedGameObject.GetComponent<Node>() != null)
            {
                if (EventSystem.current.currentSelectedGameObject.GetComponent<Node>().Active == true)
                {
                    CNPanel.SetActive(false);
                }
                else
                {
                    CNPanel.SetActive(true);
                }
            }
        }
        Debug.Log("El gameobject es nulo");
    }

    public void NavigateScene(string sceneName)
    {

        /*
        switch (sceneName)
        {
            case "CM_1_AssemblyLines": Game.Instance.LoadScene(sceneName); break;
            case "CM_2_RobotInventory": Game.Instance.LoadScene(sceneName); break;
            case "CM_3_Extractions": Game.Instance.LoadScene(sceneName); break;
            case "CM_4_BattleList": Game.Instance.LoadScene(sceneName); break;
            case "CM_4.1_BattlePreparation": Game.Instance.LoadScene(sceneName); break;
            case "CM_4.2_Minigame": Game.Instance.LoadScene(sceneName); break;
        }
        */

        ScenesManager.GoToScene(sceneName);

        //Debug.Log("Escena : " + sceneName);
    }

    public void PrepareToBattle()
    {
        if (this.CurrentSelectedMission != null)
        {
            ScenesManager.GoToScene(Game.GameInstance.GameData.ScenesNames[4]);
        }
    }

    public void CreateNode(GameObject createNodePanel)
    {
        createNodePanel.SetActive(true);
    }

    public void CancelCreation()
    {
        GameObject.Find("CreateNodePanel").SetActive(false);
    }

    public void CreateNewNode(GameObject A_Line_Panel)
    {
        Debug.Log("Cree un nuevo nodo");


    }

    public void CreateNode()
    {
        if (currentAssemblyLineSelected != null && currentNodeSelected != null)
        {
            currentAssemblyLineSelected.AssemblyLineNodes.Add(currentNodeSelected.node_id, currentNodeSelected);
            Debug.Log("ID = " + currentAssemblyLineSelected.assembly_Line_Id);
        }
    }
}


