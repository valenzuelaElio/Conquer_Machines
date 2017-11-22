using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Extractor : MonoBehaviour , ITemplate{

    private Button MyButton; //Interaction;

    //Aqui va toda la informacion que sera mostrada en el template creado;
    public DataExtractor MyExtractor { get; set; } //Mi informacion;
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
        TotalRobots.text = "" + MyExtractor.rawMaterial_recolectedQnty;
        //Robot.sprite =  Buscar el sprite;
        //RawMaterial.sprite = Buscar el sprite;
    }

    public string Id()
    {
        return this.MyExtractor.robot_id;            
    }
    public string Description()
    {
        return "";
    }
    public int Cant()
    {
        return MyExtractor.robot_Left;
    }

    public void Start()
    {
        this.MyExtractor.PrepareToExtract(Game.GameInstance.GameData,10);

        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(Selected);
    }

    public void Update()
    {
        this.MyExtractor.Extract(Time.time);
        ShowData();
    }

    public void Harvest()
    {
        Game.GameInstance.currentSelectedExtractor.Harvest();
    }

    public void Selected()
    {
        Game.GameInstance.currentSelectedExtractor = this.MyExtractor;
    }

}   
