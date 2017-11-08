using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RobotInfoPanel : MonoBehaviour {

    private Robot CurrentRobot;

    public Image robotImage;
    public Text robotName;
    public Text robotDescription;
    public Text robotStats;

	// Use this for initialization
	void Start () {
        //Robot tempRobot = GameState.Instance.GameData.Robots[0];

        //robotName.text = tempRobot.RobotID;
        //robotDescription.text = tempRobot.Description;
        //robotStats.text =   "Lifepoints : " + tempRobot.LifePoints + 
                            //"\nDurability : " + tempRobot.Durability + 
                            //"\nEnergy Cost : " + tempRobot.EnergyCost;

    }
	
    public void SearchInfo()
    {
        string id = EventSystem.current.currentSelectedGameObject.GetComponent<RobotTemplate>().robotName.text;
        Debug.Log("ID = " + id);

        CurrentRobot = SearchRobot(id);

        robotName.text = CurrentRobot.RobotID;
        robotDescription.text = CurrentRobot.Description;
        robotStats.text = "Lifepoints : " + CurrentRobot.LifePoints +
                            "\nDurability : " + CurrentRobot.ProbBreaking +
                            "\nEnergy Cost : " + CurrentRobot.EnergyCost;
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
        Debug.LogError("No se encontro la mision");
        return robotList[0];

    }
}
