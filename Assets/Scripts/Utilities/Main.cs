using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    private static string path = "Data";

    public void StartGame()
    {
        Game.CreateGame(DataManager.DataMaster); //Empeize el juego ("GameLoop").
    }

    void Awake()
    {
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //TODO: Se carga la informacion antes de comenzar el juego.
        //DataManager.CreateDataMapExample(path);
        DataManager.Load(path);
        //DataManager.DeserializeData(path);
        DataManager.ListLoading();
        ScenesManager.LastLoadedScene = DataManager.DataMaster.ScenesNames[0];
    }

    public void Play()
    {
        ScenesManager.GoToScene(Game.GameInstance.GameData.ScenesNames[1]);
    }

    //TODO: "Exit"? y "Options".
}
