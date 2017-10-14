using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState {

    //private Data gamedata;
    private static GameState gameState;
    private PlayerState playerState;
    private DataManager dataManager;
    private string lastScene;

    //public Data GameData { get { return gamedata; } set { gamedata = value; } }
    public static GameState Instance { get { return gameState; } set { gameState = value; } }
    public PlayerState PlayerStateInstance { get { return playerState; } set { playerState = value; } }
    public DataManager DataManagerInstance { get { return dataManager; } set { dataManager = value; } }
    public string LastScene { get { return lastScene; } set { lastScene = value; } }

    public enum State
    {
        Loading,
        Playing,
        GameOver,

    }
    private State actualState;
    public State ActualState { get { return actualState; } set { actualState = value; } }

    public GameState(string XMLpath)
    {
        dataManager = new DataManager(XMLpath); // Se crea un nuevo DataManager
        Start();
    }

    public static void CreateGame(string XMLpath)
    {
        gameState = new GameState(XMLpath);

    }

    public void Start()
    {
        LoadScene(dataManager.DataMaster.ScenesNames[1]);
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
