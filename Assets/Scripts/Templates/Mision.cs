using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mision : MonoBehaviour, ITemplate {

    Button MyButton;

    public DataMision MyMision { get; set; }
    public Text misionName;

    public int Cant()
    {
        return 1;
    }

    public string Description()
    {
        return MyMision.Description;
    }

    public string Id()
    {
        return MyMision.mision_Id;
    }

    public void ShowData()
    {
        misionName.text = "" + MyMision.mision_Name;
    }

    public void Start()
    {
        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(Selected);
    }

    public void Selected()
    {
        Game.GameInstance.currentSelectedMision = this.MyMision;
    }
}
