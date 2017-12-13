using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToExtractor : MonoBehaviour {

    private Button addRobot;
    public GameObject addRobotPanel;
    private bool isActive = false;

    void Start () {
        addRobotPanel.SetActive(isActive);

        this.addRobot = GetComponent<Button>();
        this.addRobot.onClick.AddListener(ShowSceneInfo);
    }

    private void ShowSceneInfo()
    {
        this.addRobotPanel.SetActive(!isActive);
        this.isActive = !isActive;
    }
}
