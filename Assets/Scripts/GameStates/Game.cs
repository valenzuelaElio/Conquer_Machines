using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game {

    public List<AssemblyLine> LineasDeEnsamblaje = new List<AssemblyLine>();
    public AssemblyLine currentSelectedAssemblyLine = null;
    public bool AssemblyLineSelected = false;

    public Node currentSelectedNode = null;
    public Node currentSelectedCoreNode = null;
    public Node currentSelectedUpgradeNode = null;
    public Node tempNode = null;
    public bool NodeSelected = false;


    public Extractor currentSelectedExtractor;
    public DataMision       currentSelectedMision;
    public RawMaterial currentSelectedRawMaterial;
    public RawMaterial tempRawMaterial;


    public Robot currentSelectedRobot;
    public Robot tempRobot;


    

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
        GuardarTiempoLineasDeEnsamblaje();
    }

    public void AddLineaDeEnsamblaje(AssemblyLine al)
    {
        bool exist = false;
        foreach (AssemblyLine temp in LineasDeEnsamblaje)
        {
            if (temp.MyAssemblyLine.assembly_Line_Id == al.MyAssemblyLine.assembly_Line_Id)
            {
                exist = true;
            }
        }

        if (exist == false)
        {
            LineasDeEnsamblaje.Add(al);
            Debug.Log("Exito");
        }
    }

    public void GuardarTiempoLineasDeEnsamblaje()
    {
        foreach (AssemblyLine linea in LineasDeEnsamblaje)
        {
            if (linea.Nodes[0].GetComponent<Node>().MyNode != null)
            {
                linea.SaveTime();
                Debug.Log("Exito Al guardar el tiempo de " + linea.MyAssemblyLine.assembly_Line_Id);
            }
        }
    }



}
