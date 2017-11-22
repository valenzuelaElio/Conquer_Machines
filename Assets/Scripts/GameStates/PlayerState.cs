using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState{
    //TODO: informacion del jugador. Guardado y Cargado

    public string Player_name { get; set; }
    public List<DataAssemblyLine> MyAssemblyLines { get; set; }
    private int AL_index;
    public Dictionary <string, int> RobotInventory { get; set; }
    public Dictionary <string, bool> Missions_completed { get; set; }
    public Dictionary <string, int> RM_Inventory { get; set; } //Inventario de materias primas y su cantidad;

    public PlayerState()
    {
        //TODO: Definir informacion de instanciamiento.
        Missions_completed = new Dictionary<string, bool>();
        RM_Inventory = new Dictionary<string, int>();
        RobotInventory = new Dictionary<string, int>();
        MyAssemblyLines = new List<DataAssemblyLine>();

    }

    public void NewPlayer(Data data)
    {
        LoadAllAssemblyLines(data);
        LoadAllRawMaterials(data);
        LoadAllMissions(data);
        LoadAllRobots(data);
    }

    //FT = First Time Load Only
    private void LoadAllRawMaterials(Data data)
    {
        for (int i = 0; i < DataManager.AllRawMaterials.Count; i++)
        {
            if (data.RawMaterials[i] != null) {
                RM_Inventory.Add(data.RawMaterials[i].RawMaterialID, 0); //Esto se llamaria solo la primera vez;
            }
        }
    }

    private void LoadAllMissions(Data data)
    {
        for (int i = 0; i < data.RawMaterials.Length; i++)
        {
            if (data.Misions[i] != null) {
                this.Missions_completed.Add(data.Misions[i].mision_Id, data.Misions[i].isCompleted);
            }
        }
    }

    private void LoadAllRobots(Data data)
    {
        for (int i = 0; i < data.Robots.Length; i++)
        {
            if (data.Robots[i] != null) {
                this.RobotInventory.Add(data.Robots[i].robot_id, 10);
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


}
