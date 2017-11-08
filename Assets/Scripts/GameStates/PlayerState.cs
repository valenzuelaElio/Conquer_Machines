using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState{
    //TODO: informacion del jugador. Guardado y Cargado

    private string player_name;
    private string last_material;
    private int robot_inventory;
    private int missions_completed;

    public string Player_name { get { return player_name; } set { player_name = value; } }
    public string Last_material { get { return last_material; } set { last_material = value; } }
    public int Robot_inventory { get { return robot_inventory; } set { robot_inventory = value; } }
    public int Missions_completed { get { return missions_completed; } set { missions_completed = value; } }

    public PlayerState()
    {
        //TODO: Definir informacion de instanciamiento.
    }

}
