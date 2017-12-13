using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour, ITemplate {


    public DataNode MyNode;
    public bool onList;
    public int lineIndex;

    public bool isCore;
    public bool Active;

    public Text Name;
    public Sprite ActiveOn;
    public Sprite ActiveOff;

    Button MyButton;
    Image MyImage;
    Color originalColor;


    void Start () {


        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(Selected);

        this.MyImage = GetComponent<Image>();
        this.originalColor = this.MyImage.color;

        //Debug.Log(this.MyNode.path);
        if (this.MyNode != null)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/" + this.MyNode.path);
            this.MyImage.sprite = sprites[this.MyNode.spriteIndex];

            //Decidir si es core o no;
            if (this.MyNode.GetType() == typeof(Core))
            {
                this.isCore = true;
            }
            else if (this.MyNode.GetType() == typeof(Upgrade))
            {
                this.isCore = false;
            }
        }

        Active = false;
        ChangeSprite();
	}
	
    void ChangeSprite()
    {

        if(MyNode == null)
        {
            return;
        }

        if (onList == false)
        {
            if (Active == true)
            {
                //MyImage.sprite = ActiveOn;
                //Name.text = "";
            }
            else
            {
                //MyImage.sprite = ActiveOff;
                //Name.text = "Desactivado";

            }

        }
        else
        {
            if (Name != null)
            {
                this.Name.text = "" + this.MyNode.node_id;
            }

            if (Game.GameInstance.PlayerInstance.NodeQnty[this.MyNode.node_id] > 0)
            {
                this.MyButton.interactable = true;
            }
            else
            {
                this.MyButton.interactable = false;
            }
        }
        
    }

    void Selected()
    {
        if(ScenesManager.LastLoadedScene == "CM_2_RobotInventory")
        {
            if (GenericListController.selected == 1)
            {
                if (Game.GameInstance.PlayerInstance.RM_Inventory[this.MyNode.rawMaterial1] >= this.MyNode.cant1
                && Game.GameInstance.PlayerInstance.RM_Inventory[this.MyNode.rawMaterial2] >= this.MyNode.cant2
                && Game.GameInstance.PlayerInstance.RM_Inventory[this.MyNode.rawMaterial3] >= this.MyNode.cant3)
                {

                    StartCoroutine(showCants());

                    Game.GameInstance.PlayerInstance.RM_Inventory[this.MyNode.rawMaterial1] -= this.MyNode.cant1;
                    Game.GameInstance.PlayerInstance.RM_Inventory[this.MyNode.rawMaterial2] -= this.MyNode.cant2;
                    Game.GameInstance.PlayerInstance.RM_Inventory[this.MyNode.rawMaterial3] -= this.MyNode.cant3;

                    Game.GameInstance.PlayerInstance.NodeQnty[this.MyNode.node_id]++;
                    Debug.Log("Nodo " + this.MyNode.node_id + " = " + Game.GameInstance.PlayerInstance.NodeQnty[this.MyNode.node_id]);
                }
            }
            GenericListController.selected = 1;
            UpdateSprite.NeedUpdate = true;
            Game.GameInstance.currentSelectedNode = this;
        }


        if (ScenesManager.LastLoadedScene == "CM_1_AssemblyLines")
        {
            if (Game.GameInstance.currentSelectedNode == null)
            {
                this.ShowPanel();
                Game.GameInstance.currentSelectedNode = this;
                Game.GameInstance.currentSelectedAssemblyLine = this.gameObject.GetComponentInParent<AssemblyLine>();

                //for (int i = 1; i < 3; i++)
                //{
                //    Game.GameInstance.currentSelectedAssemblyLine.Nodes[1];
                //}
                //Debug.Log("First Selected");
            }

            if (this.onList == true)
            {
                if ( this.MyNode.GetType() == typeof(Core) )
                {
                    Game.GameInstance.currentSelectedCoreNode = this;
                    //Debug.Log("Second Selected");
                }else if (this.MyNode.GetType() == typeof(Upgrade))
                {
                    Game.GameInstance.currentSelectedUpgradeNode = this;
                    //Debug.Log("Second Selected");
                }
                
            }
        }
    }

    public void ShowPanel()
    {
        if (ScenesManager.LastLoadedScene == "CM_1_AssemblyLines")
        {
            Game.GameInstance.currentSelectedNode = this;
            SelectedNode.change = true;
            SelectedNode.UpdateList = true;
        }
    }

    private void Update()
    {
        if (Game.GameInstance.currentSelectedNode == null)
        {
            return;
        }

        if (Game.GameInstance.currentSelectedNode.MyNode == this.MyNode)
        {
            this.MyImage.color = Color.blue * 0.5f;
        }
        else
        {
            this.MyImage.color = originalColor;
        }
        
    }

    public void UpdateImage()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/" + this.MyNode.path);
        this.MyImage.sprite = sprites[this.MyNode.spriteIndex];
    }

    public void ShowData()
    {
        return;
    }

    public string Id()
    {
        return this.MyNode.node_id;
    }

    public string Description()
    {
        return this.MyNode.rawMaterial1;
    }

    public int Cant()
    {
        if (Game.GameInstance.PlayerInstance.NodeQnty.ContainsKey(this.MyNode.node_id))
        {
            return Game.GameInstance.PlayerInstance.NodeQnty[this.MyNode.node_id];
        }
        else
        {
            return 0;
        }
    }

    IEnumerator showCants()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject cant1 = new GameObject("Cant1");
            cant1.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
            cant1.transform.SetAsLastSibling();
            cant1.transform.position = this.gameObject.GetComponent<Transform>().position;

            if (i == 0)
            {
                cant1.AddComponent<Text>().text = "-" + this.MyNode.cant1;
            }else if(i == 1)
            {
                cant1.AddComponent<Text>().text = "-" + this.MyNode.cant2;
            }else if (i == 2)
            {
                cant1.AddComponent<Text>().text = "-" + this.MyNode.cant3;
            }

            cant1.GetComponent<Text>().font = Resources.Load<Font>("Fonts/Classic Robot");
            cant1.GetComponent<Text>().fontSize = 30;

            cant1.AddComponent<MoveUpAndDissapear>();
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }

}
