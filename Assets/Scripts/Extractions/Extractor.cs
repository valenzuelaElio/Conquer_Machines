using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Extractor : MonoBehaviour , ITemplate{

    private Button MyButton; //Interaction;

    //Aqui va toda la informacion que sera mostrada en el template creado;
    public Slider RobotsLeft;
    public DataExtractor MyExtractor { get; set; } //Mi informacion;
    public Text ExtractorID;
    public Text TotalRobots;
    public Image Robot;
    public Image RawMaterial;
    public Sprite SpriteRobot { get { return Robot.sprite; } }
    public Sprite SpriteRawMaterial { get { return RawMaterial.sprite; } }

    public void ShowData()
    {
        ExtractorID.text = "" + MyExtractor.Id;
        TotalRobots.text = "" + MyExtractor.rawMaterial_recolectedQnty;
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
        if (this.MyExtractor != null && this.MyExtractor.rawMaterial_Id != "" && this.MyExtractor.robot_id != "")
        {
            this.MyExtractor.PrepareToExtract(Game.GameInstance.GameData, Game.GameInstance.PlayerInstance.RobotQnty[this.MyExtractor.robot_id]);
            this.InitializeRobotLeft();
        }
        

        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(Selected);
    }

    public void Update()
    {
        if (this.MyExtractor != null && this.MyExtractor.rawMaterial_Id != "" && this.MyExtractor.robot_id != "")
        {
            this.MyExtractor.Extract(Time.time);
            this.updateRobotsLeft();
            ShowData();

            if (this.MyExtractor.robot_initialQnty <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }

    public void Harvest()
    {
        if (this.MyExtractor != null)
            Debug.Log("MyExtractor no es nulo");
            Game.GameInstance.currentSelectedExtractor.MyExtractor.Harvest();
    }

    public void Selected()
    {
        Game.GameInstance.currentSelectedExtractor = this;
    }

    public void InitializeRobotLeft()
    {
        this.RobotsLeft.maxValue = this.MyExtractor.robot_initialQnty;
    }
    private void updateRobotsLeft()
    {
        this.RobotsLeft.value = this.MyExtractor.robot_Left;
    }

}   
