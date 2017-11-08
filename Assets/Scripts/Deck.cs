using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Deck : MonoBehaviour{

    public Robot[] RobotList;
    Robot currentSElectedRobot;
    int currentListPos;

	void Start () {
        RobotList = new Robot[10]; //TODO: conectarlo con las caracteristicas de la mision
        currentListPos = 0;
	}

    public void AddRobotToDeck()
    {
        RobotList[currentListPos] = currentSElectedRobot;
        Debug.Log("R = " + RobotList[currentListPos].RobotID);
        Debug.Log("Pos = " + currentListPos);
        currentListPos++;
    }

    public void selectedRobot()
    {
        string id = EventSystem.current.currentSelectedGameObject.GetComponent<RobotTemplate>().robotName.text;
        Debug.Log("ID = " + id);
        currentSElectedRobot = SearchRobot(id);
    }

    Robot SearchRobot(string id)
    {
        Robot[] robotList = Game.Instance.GameData.Robots;
        foreach (Robot temp in robotList)
        {
            if (temp.RobotID.Equals(id))
            {
                return temp;
            }
        }
        Debug.LogError("No se encontro al robot");
        return robotList[0];

    }

    public void DeckReady()
    {
        GameManager.Instance.ChoosedDeck = this;
    }

}
