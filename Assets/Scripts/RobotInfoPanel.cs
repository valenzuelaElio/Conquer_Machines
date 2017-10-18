using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotInfoPanel : MonoBehaviour {

    public Image robotImage;
    public Text robotName;
    public Text robotDescription;
    public Text robotStats;

	// Use this for initialization
	void Start () {
        Robot tempRobot = GameState.Instance.GameData.Robots[0];

        robotName.text = tempRobot.RobotID;
        robotDescription.text = tempRobot.Description;
        robotStats.text =   "Lifepoints : " + tempRobot.LifePoints + 
                            "\nDurability : " + tempRobot.Durability + 
                            "\nEnergy Cost : " + tempRobot.EnergyCost;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
