using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Deck : MonoBehaviour{

    public List<DataRobot> DeckList = new List<DataRobot>();
    public int DeckSize { get { return DeckList.Count; } }
    private DataMision currentMision;
    public Text[] DeckInfo;//LevelDeckController
    DataRobot LastRobotAdded;

    int currentLevelOfDeck;
    int maxLevel;
    int minLevel;

    private Image MyImage;
    private Button MyButton;

	void Start () {
        currentMision = Game.GameInstance.currentSelectedMision;
        currentLevelOfDeck = 0;
        minLevel = currentMision.MinDeckLevel;
        maxLevel = currentMision.MaxDeckLevel;

        DeckList = new List<DataRobot>();
        ShowLevels();

        MyImage = GetComponent<Image>();
        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(AddSelectedRobot);

        if (currentLevelOfDeck <= minLevel)
        {
            MyImage.color = Color.blue;
        }
	}

    public void ShowLevels()
    {
        DeckInfo[0].text = "" + minLevel;
        DeckInfo[1].text = "" + currentLevelOfDeck;
        DeckInfo[2].text = "" + maxLevel;
    }

    private void AddSelectedRobot()
    {
        if (Game.GameInstance.currentSelectedRobot == null)
        {
            DeckList.Remove(LastRobotAdded);
            UpdateLevelOfDeck(false);
            //Debug.Log("No has seleccionado ningun robot");
            //Debug.Log("Robot " + LastRobotAdded.robot_id + " Eliminado");
            LastRobotAdded = null;
            return;
        }
        else
        {
            if (currentLevelOfDeck < maxLevel)
            {
                DeckList.Add(Game.GameInstance.currentSelectedRobot);
                LastRobotAdded = Game.GameInstance.currentSelectedRobot;
                UpdateLevelOfDeck(true);
                Game.GameInstance.currentSelectedRobot = null;
                //Debug.Log("Se ha a♫adido correctamente");
            }
        }

        UpdateColors();

    }

    private void UpdateLevelOfDeck(bool added)
    {
        if (added == true)
        {
            currentLevelOfDeck += LastRobotAdded.robot_level;
        }
        else
        {
            currentLevelOfDeck -= LastRobotAdded.robot_level;
        }
        ShowLevels();
    }

    void UpdateColors()
    {
        if (currentLevelOfDeck < minLevel)
        {
            MyImage.color = Color.gray;
            return;
        }

        if (currentLevelOfDeck > maxLevel)
        {
            MyImage.color = Color.red;
            return;
        }

        MyImage.color = Color.green;
    }

    public void DeckReady()
    {
        if (currentLevelOfDeck >= minLevel && currentLevelOfDeck <= maxLevel)
        {
            Game.GameInstance.BattleDeck = this.DeckList;
            ScenesManager.GoToScene(Game.GameInstance.GameData.ScenesNames[6]);
            Debug.Log("Go to Battle");
        }
    }


}
