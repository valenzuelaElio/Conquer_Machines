using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerState {
    //TODO: informacion del jugador. Guardado y Cargado

    public string Player_name { get; set; }
    public List<DataAssemblyLine> MyAssemblyLines { get; set; }
    private int AL_index;

    public Dictionary<string, int> RobotQnty { get; set; }
    public Dictionary<string, DataRobot> Player_Robots { get; set; }

    public Dictionary<string, int> NodeQnty { get; set; }
    public Dictionary<string, DataNode> Player_Nodes { get; set; }

    public Dictionary<string, DataMision> Playable_Mission;
    public Dictionary<string, bool> Missions_completed { get; set; }

    public Dictionary<string, int> RM_Inventory { get; set; } //Inventario de materias primas y su cantidad;

    public PlayerState()
    {
        //TODO: Definir informacion de instanciamiento.
        Playable_Mission = new Dictionary<string, DataMision>();
        Missions_completed = new Dictionary<string, bool>();

        RM_Inventory = new Dictionary<string, int>();

        RobotQnty = new Dictionary<string, int>();
        Player_Robots = new Dictionary<string, DataRobot>();

        NodeQnty = new Dictionary<string, int>();
        Player_Nodes = new Dictionary<string, DataNode>();

        MyAssemblyLines = new List<DataAssemblyLine>();

    }

    public void NewPlayer(Data data)
    {
        InitializeRawMaterials( DataManager.AllRawMaterials );


        LoadAllAssemblyLines(data);
        LoadAllMissions(data);
        //LoadAllRobots(data);
        LoadAllNodes(data);
    }


    /*
     * Inicializa el inventario de materias primas del Jugador;
     */
    private void InitializeRawMaterials( List<DataRawMaterial> rawMaterials )
    {
        for (int i = 0; i < rawMaterials.Count; i++)
            if ( rawMaterials[i] != null )
                RM_Inventory.Add( rawMaterials[i].RawMaterialID, 0 );
    }

    private void LoadAllMissions(Data data)
    {
        for (int i = 0; i < data.Misions.Length; i++)
        {
            if (data.Misions[i] != null) {
                this.Playable_Mission.Add(data.Misions[i].mision_Id, data.Misions[i]);
                this.Missions_completed.Add(data.Misions[i].mision_Id, data.Misions[i].isCompleted);
            }
        }
    }

    private void LoadAllRobots(Data data)
    {
        for (int i = 0; i < data.Robots.Length; i++)
        {
            if (data.Robots[i] != null) {
                this.RobotQnty.Add(data.Robots[i].robot_id, 0);
            }
        }
    }

    private void LoadAllAssemblyLines(Data data)
    {
        for (int i = 0; i < data.AssemblyLines.Length; i++)
        {
            if (data.AssemblyLines[i] != null)
            {
                this.MyAssemblyLines.Add(data.AssemblyLines[i]);
            }
        }
    }

    private void LoadAllNodes(Data data)
    {
        for (int i = 0; i < data.Nodes.Length; i++)
            if (data.Nodes[i] != null)
            {
                this.NodeQnty.Add(data.Nodes[i].node_id, 0);
                this.Player_Nodes.Add(data.Nodes[i].node_id, data.Nodes[i]);
            }
    }


}
