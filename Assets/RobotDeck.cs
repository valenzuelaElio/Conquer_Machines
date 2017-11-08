using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RobotDeck : MonoBehaviour {

    Deck SelectionDeck;
    private Robot[] Allrobots;
    private Robot currentSelectedRobot;
    public GameObject robotIconTemplate;
    public GameObject robotIconDeck;

    void Start()
    {
        //Game.CreateBattle();
        Allrobots = GameManager.Instance.ChoosedDeck.RobotList;
        //currentSelectedRobot = Allrobots[0]; // Por mientras el robot escogido siepmre sera el primero
        for (int i = 0; i < Allrobots.Length; i++)
        {
            GameObject robot = Instantiate(robotIconDeck) as GameObject;
            robot.SetActive(true);

            robot.name = Allrobots[i].RobotID;

            //robot.GetComponent<RobotBattle>().MyRobot = Allrobots[i];

            robot.transform.SetParent(robotIconDeck.transform.parent, false);
        }
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                Transform t = hit.collider.transform;
                if(t.childCount == 0) //Si donde hago click esta vacio
                {
                    if (currentSelectedRobot != null)
                    {
                        GameObject g = Instantiate(robotIconTemplate, t.position, gameObject.transform.rotation) as GameObject;
                        g.GetComponent<RobotGo>().MyRobot = this.currentSelectedRobot;
                        g.transform.SetParent(t);
                    }
                }
            }
        }
    }

    public void SearchInfo()
    {
        string id = EventSystem.current.currentSelectedGameObject.GetComponent<RobotBattle>().name;
        Debug.Log("ID = " + id);
        currentSelectedRobot = SearchRobot(id);
        Debug.Log("Robot - ID = " + currentSelectedRobot.RobotID);
    }

    Robot SearchRobot(string id)
    {
        //Robot[] robotList = Game.Instance.GameData.Robots;
        foreach (Robot temp in Allrobots)
        {
            if (temp.RobotID.Equals(id))
            {
                return temp;
            }
        }
        Debug.LogError("No se encontro al Robot");
        return null;
    }
}
