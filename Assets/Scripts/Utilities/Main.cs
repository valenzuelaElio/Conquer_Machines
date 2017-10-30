using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    private static string path = "test001Xml";

    public void StartGame()
    {
        GameState.CreateGame(DataManager.DataMaster);
    }

    void Awake()
    {
        DataManager.CreateDataMapExample(path);
    }
}
