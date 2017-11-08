using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game {

    //private Data gamedata;
    private static Game game;
    private PlayerState playerState; //Informacion del jugador.
    private Data gameData;
    private string lastScene;

    public static Game Instance { get { return game; } set { game = value; } }
    public PlayerState PlayerStateInstance { get { return playerState; } set { playerState = value; } }
    public Data GameData { get { return gameData; } set { gameData = value; } }
    public string LastScene { get { return lastScene; } set { lastScene = value; } }

    public enum GameState
    {
        Loading,
        Inventory, //Scene
        BattleList, //Scene
        AssemblyLines, //Scene
        Extractions, //Scene
        Playing,
        GameOver

    }
    private GameState actualState;
    public GameState ActualState { get { return actualState; } set { actualState = value; } }

    public Game(Data data)
    {
        playerState = new PlayerState(); //Se crea al jugador con la informacion vacia. que el jugador cargue su informacion.
        gameData = data;
    }

    public static void CreateGame(Data data)
    {
        game = new Game(data);
        game.Start();

    }

    public static void CreateBattle() //TODO: Eliminar esto
    {
        DataManager.CreateDataMapExample("test001Xml");
        game = new Game(DataManager.DataMaster);
    }

    public void Start()
    {
        LoadScene(GameData.ScenesNames[1]);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        lastScene = sceneName;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(lastScene);
    }

    public void LoadData()
    {

    }

    public void SaveData()
    {

    }


}
