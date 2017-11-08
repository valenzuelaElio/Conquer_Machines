using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    private static string path = "test001Xml";

    public void StartGame()
    {
        Game.CreateGame(DataManager.DataMaster); //Empeize el juego ("GameLoop").
    }

    void Awake()
    {
        //TODO: Se carga la informacion antes de comenzar el juego.
        DataManager.CreateDataMapExample(path);
    }

    //TODO: "Exit"? y "Options".
}
