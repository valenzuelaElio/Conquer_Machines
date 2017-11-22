using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawMaterial : MonoBehaviour, ITemplate {

    Button MyButton;
    DataRawMaterial MyRawMaterial;

    public int Cant()
    {
        return 0;
    }
    public string Description()
    {
        return this.MyRawMaterial.Description;
    }
    public string Id()
    {
        return this.MyRawMaterial.RawMaterialID;
    }

    public void ShowData()
    {

    }

    void Start () {
        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(Selected);
	}
	
	void Update () {
		
	}

    public void Selected()
    {
        Game.GameInstance.currentSelectedRawMaterial = this.MyRawMaterial;
    }
}
