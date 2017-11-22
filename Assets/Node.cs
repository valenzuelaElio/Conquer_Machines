using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour, ITemplate {

    Button MyButton;
    public DataNode MyNode;
    public bool Active;

    public Text type;
    public Sprite ActiveOn;
    public Sprite ActiveOff;
    Image MyImage;

	// Use this for initialization
	void Start () {
        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(Selected);

		MyImage = GetComponent<Image>();
        Active = false;
        ChangeSprite();
	}
	
    void ChangeSprite()
    {
        if(MyNode == null)
        {
            return;
        }

        if (Active == true)
        {
            MyImage.sprite = ActiveOn;
            type.text = "Activado";
        }
        else
        {
            MyImage.sprite = ActiveOff;
            type.text = "Desactivado";

        }
    }

    void Selected()
    {
        if (Active == true)
        {
            //Show Info Only
        }
        else
        {
            Debug.Log(this.MyNode.node_id + " Seleccionado");
            Game.GameInstance.currentSelectedNode = this.MyNode;
        }
    }

    public void ShowData()
    {
        throw new System.NotImplementedException();
    }

    public string Id()
    {
        throw new System.NotImplementedException();
    }

    public string Description()
    {
        throw new System.NotImplementedException();
    }

    public int Cant()
    {
        throw new System.NotImplementedException();
    }
}
