using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtractorTemplate : MonoBehaviour{

    //Aqui va toda la informacion que sera mostrada en el template creado;
    public Extractor MyExtractor { get; set; } //Mi informacion;
    public Text ID;
    public Text TotalRobots;
    public Image Robot;
    public Image RawMaterial;
    //public ProgressBarBehaviour progressBar;

    public void ShowData()
    {
        ID.text = "" + MyExtractor.Id;
        TotalRobots.text = "" + MyExtractor.RobotCant; 
        //Robot.sprite =  Buscar el sprite;
        //RawMaterial.sprite = Buscar el sprite;
    }

}   
