using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState {

    //private Data gamedata;
    private static GameState gameState;
    private PlayerState playerState;
    private Data gameData;
    private string lastScene;

    //public Data GameData { get { return gamedata; } set { gamedata = value; } }
    public static GameState Instance { get { return gameState; } set { gameState = value; } }
    public PlayerState PlayerStateInstance { get { return playerState; } set { playerState = value; } }
    public Data GameData { get { return gameData; } set { gameData = value; } }
    public string LastScene { get { return lastScene; } set { lastScene = value; } }

    public enum State
    {
        Loading,
        Playing,
        GameOver,

    }
    private State actualState;
    public State ActualState { get { return actualState; } set { actualState = value; } }

    public GameState(Data data)
    {
        gameData = data;
    }

    public static void CreateGame(Data data)
    {
        gameState = new GameState(data);
        gameState.Start();

    }

    public static void CreateBattle()
    {
        DataManager.CreateDataMapExample("test001Xml");
        gameState = new GameState(DataManager.DataMaster);
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
