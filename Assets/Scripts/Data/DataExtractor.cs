using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System;

[Serializable]
public class DataExtractor {

    [XmlElement("EX-ID")] public string Id;

    [XmlElement("RM-ID")] public string rawMaterial_Id;
    [XmlElement("RM-InitialQuantity")] public int rawMaterial_initialQnty;
    [XmlElement("RM-Recolected")] public int rawMaterial_recolectedQnty;

    [XmlElement("R-ID")] public string robot_id;
    [XmlElement("R-InitialRobotQuantity")] public int robot_initialQnty;
    [XmlElement("R-RobotLeft")] public int robot_Left;

    [XmlIgnore] float StartTime;
    [XmlIgnore] float TimesTamp;
    [XmlIgnore] float ExtractTime;
    [XmlIgnore] float Robot_Duration;
    [XmlIgnore] float RobotSaved_Duration;
    [XmlIgnore] const float MaxTime = 10;//72000; //milisegundos; Maximo valor calculado = 30 min.


    public DataExtractor()
    {
        //TODO: Guardar la informacion aun cuando se cambie de escena; - 1
    }

    public void Harvest()
    {
        int playerSavedQnty = Game.GameInstance.PlayerInstance.RM_Inventory[rawMaterial_Id];
        if (Game.GameInstance.PlayerInstance.RM_Inventory.ContainsKey(rawMaterial_Id))
        {
            Game.GameInstance.PlayerInstance.RM_Inventory[rawMaterial_Id] = playerSavedQnty + rawMaterial_recolectedQnty;
        }
        //Game.GameInstance.PlayerInstance.RM_Inventory.Add(rawMaterial_Id , playerSavedQnty + rawMaterial_recolectedQnty);//Se suma lo guardado mas lo nuevo.
        rawMaterial_recolectedQnty = 0; // Se reinicia lo recolectado.
    }

    public void Extract(float time)
    {
        if (robot_Left > 0) {
            TimesTamp = time - StartTime;
            if (TimesTamp > ExtractTime)
            {
                this.rawMaterial_recolectedQnty++;
                StartTime = time;
            }

            if (Robot_Duration <= 0)
            {
                this.robot_Left--;
                this.Robot_Duration = this.RobotSaved_Duration;
            }
        }
        else
        {
            StartTime = 0;
        }
        //Debug.Log(this.robot_Left);
        //Debug.Log(this.robot_initialQnty);
        //Debug.Log(this.TimesTamp);
        //Debug.Log(this.StartTime);
        //Debug.Log(this.ExtractTime);
        //Debug.Log(rawMaterial_recolectedQnty);


    }

    private void CalculateExtractTime(Data data)
    {
        int robot_Level = SearchRobotDuration(this.robot_id, data).robot_level;
        int rawMaterial_Rarity = SearchRawMaterial(this.rawMaterial_Id, data).Rarity;

        ExtractTime = rawMaterial_Rarity * (MaxTime / robot_Level);
    }

    public void StartToExtract()
    {
        this.StartTime = Time.time;
        this.rawMaterial_recolectedQnty = 0;
    }

    public void PrepareToExtract(Data data, int initialQnty)
    {
        this.robot_initialQnty = initialQnty;
        this.robot_Left = initialQnty;

        this.RobotSaved_Duration = SearchRobotDuration(this.robot_id, data).Duration;
        this.Robot_Duration = this.RobotSaved_Duration;

        CalculateExtractTime(data);
        StartToExtract();
    }

    public DataRobot SearchRobotDuration(string robot_id , Data data)
    {
        for (int i = 0; i < data.Robots.Length; i++)
        {
            if (data.Robots[i].robot_id.Equals(robot_id))
            {
                return data.Robots[i];
            }
        }
        return null;
    }

    public DataRawMaterial SearchRawMaterial(string rawMaterial_id, Data data)
    {
        for (int i = 0; i < data.RawMaterials.Length; i++)
        {
            if (data.RawMaterials[i].RawMaterialID.Equals(rawMaterial_id))
            {
                return data.RawMaterials[i];
            }
        }
        return null;
    }



}
