﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiniGameDeck : MonoBehaviour {

    private bool isPaused;
    private List<DataRobot> DeckList = new List<DataRobot>();

    public GameObject Battle_Robot;
    public GameObject Deck_Robot;

    void Start()
    {
        isPaused = false;
        DeckList = Game.GameInstance.BattleDeck;
        Debug.Log("Deck size = " + DeckList.Count);
        for (int i = 0; i < DeckList.Count; i++)
        {
            GameObject robot = Instantiate(Deck_Robot) as GameObject;
            robot.SetActive(true);
            //robot.name = DeckList[i].robot_id;
            robot.GetComponent<Robot>().robotName.text = DeckList[i].robot_id;
            robot.GetComponent<Robot>().MyRobot = DeckList[i];
            robot.transform.SetParent(Deck_Robot.transform.parent, false);
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
                    if (Game.GameInstance.currentSelectedRobot != null)
                    {
                        if (Game.GameInstance.PlayerInstance.RobotInventory[Game.GameInstance.currentSelectedRobot.robot_id] > 0)
                        {
                            GameObject g = Instantiate(Battle_Robot, t.position, t.transform.rotation) as GameObject;
                            g.GetComponent<RobotGo>().MyRobot = Game.GameInstance.currentSelectedRobot;
                            Game.GameInstance.PlayerInstance.RobotInventory[Game.GameInstance.currentSelectedRobot.robot_id]--;
                            Game.GameInstance.currentSelectedRobot = null;
                            g.transform.SetParent(t);
                        }
                    }
                }
            }
        }


        if (isPaused == true)
        {
            Debug.Log(Time.timeScale);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Pause()
    {
        isPaused = !isPaused;
    }
}
