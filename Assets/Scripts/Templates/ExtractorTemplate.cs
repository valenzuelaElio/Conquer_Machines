using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtractorTemplate : MonoBehaviour , ITemplate{ 

    //Aqui va toda la informacion que sera mostrada en el template creado;
    public Extractor MyExtractor { get; set; } //Mi informacion;
    public Text ExtractorID;
    public Text TotalRobots;
    public Image Robot;
    public Image RawMaterial;
    public Sprite SpriteRobot { get { return Robot.sprite; } }
    public Sprite SpriteRawMaterial { get { return RawMaterial.sprite; } }
    //public ProgressBarBehaviour progressBar;

    public void ShowData()
    {
        ExtractorID.text = "" + MyExtractor.Id;
        TotalRobots.text = "" + MyExtractor.RobotCant;
        //Robot.sprite =  Buscar el sprite;
        //RawMaterial.sprite = Buscar el sprite;
    }

    public string Id()
    {
        Robot[] Allrobots = DataManager.DataMaster.Robots;
        foreach (Robot robot in Allrobots)
        {
            if (robot.RobotID.Equals(MyExtractor.RobotID))
            {
                return robot.RobotName;
            }
        }
        return null;
            
    }

    public string Description()
    {
        Robot[] Allrobots = DataManager.DataMaster.Robots;
        foreach (Robot robot in Allrobots)
        {
            if (robot.RobotID.Equals(MyExtractor.RobotID))
            {
                return robot.Description;
            }
        }
        return null;
    }

    public int Cant()
    {
        return MyExtractor.RobotCant;
    }

   
}   
