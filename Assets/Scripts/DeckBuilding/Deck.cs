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
    public DataRobot LastRobotAdded;

    int currentLevelOfDeck;
    int maxLevel;
    int minLevel;

    private Image MyImage;
    private Button MyButton;

    public GameObject dropSpot;

	void Start () {
        currentMision = Game.GameInstance.currentSelectedMision;
        currentLevelOfDeck = 0;
        minLevel = currentMision.MinDeckLevel;
        maxLevel = currentMision.MaxDeckLevel;

        DeckList = new List<DataRobot>();
        ShowLevels();

        MyImage = GetComponent<Image>();

        if (currentLevelOfDeck <= minLevel)
        {
            MyImage.color = Color.blue;
        }

        for (int i = 0; i <= DeckSize; i++)
        {
            GameObject gp = Instantiate(dropSpot);
            gp.SetActive(true);
            gp.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            gp.transform.SetParent(dropSpot.transform.parent);

        }

	}

    public void ShowLevels()
    {
        DeckInfo[0].text = "Minimo: " + minLevel;
        DeckInfo[1].text = "Nivel Actual: " + currentLevelOfDeck;
        DeckInfo[2].text = "Maximo: " + maxLevel;
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
                DeckList.Add(Game.GameInstance.currentSelectedRobot.MyRobot);
                LastRobotAdded = Game.GameInstance.currentSelectedRobot.MyRobot;
                UpdateLevelOfDeck(true);
                //Game.GameInstance.currentSelectedRobot = null;
                //Debug.Log("Se ha a♫adido correctamente");
            }
        }

        UpdateColors();

    }

    public void UpdateLevelOfDeck(bool added)
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

    public void UpdateColors()
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
        if (currentLevelOfDeck >= minLevel && currentLevelOfDeck <= maxLevel) { 
            if (DeckList.Count <= 0)
            {
                return;
            }
            Game.GameInstance.BattleDeck = this.DeckList;
            ScenesManager.GoToScene(Game.GameInstance.GameData.ScenesNames[6]);
            //Debug.Log("Go to Battle");
        }
    }

    public void UpdateDropSpot()
    {
        GameObject newDropSpot = Instantiate(dropSpot);
        newDropSpot.SetActive(true);
        newDropSpot.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        newDropSpot.transform.SetParent(dropSpot.transform.parent);

    }


}
