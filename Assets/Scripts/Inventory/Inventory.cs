using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private Robot[] Allrobots;
    public GameObject robotIconTemplate;

	void Start () {
        Allrobots = Game.Instance.GameData.Robots;

        for (int i = 0; i < Allrobots.Length; i++) {
            GameObject robot = Instantiate(robotIconTemplate) as GameObject;
            robot.SetActive(true);

            robot.GetComponent<RobotTemplate>().robotName.text = Allrobots[i].RobotID;

            robot.transform.SetParent(robotIconTemplate.transform.parent, false);
        }
	}
}
