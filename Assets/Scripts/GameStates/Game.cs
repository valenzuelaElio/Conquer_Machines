using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game {

    public DataExtractor    currentSelectedExtractor;
    public DataMision       currentSelectedMision;
    public DataRawMaterial  currentSelectedRawMaterial;
    public DataAssemblyLine currentSelectedAssemblyLine;
    public DataRobot        currentSelectedRobot;
    public DataNode         currentSelectedNode;
    public Core             currentSelectedCoreNode;
    public Upgrade          currentSelectedUpgradeNode;

    public List<DataRobot> BattleDeck;

    public static Game GameInstance { get; set; }
    public PlayerState PlayerInstance { get; set; }
    public Data GameData { get; set; }
    public string LastScene { get; set;}

    public enum GameState
    {
        Loading,
        Playing,
        GameOver,
        InBattle,

    }
    public GameState ActualState { get; set; }

    public Game(Data data)
    {
        PlayerInstance  = new PlayerState(); //Se crea al jugador con la informacion vacia. que el jugador cargue su informacion.
        PlayerInstance.NewPlayer(data);
        GameData        = new Data();
        LoadData(data);
    }

    public static void CreateGame(Data data)
    {
        GameInstance = new Game(data);//El data se cargo en la escena anterior en el awake
        GameInstance.LoadData(data);
        GameInstance.Start();

    }

    public void Start()
    {
        ScenesManager.LoadScenes(this.GameData.ScenesNames); //Se cargan los nombres de las escenas;
    }

    public void LoadData(Data data)
    {
        GameData = data;
    }

    public void SaveData()
    {

    }

    public void CreateNewExtractor()
    {

    }


}
