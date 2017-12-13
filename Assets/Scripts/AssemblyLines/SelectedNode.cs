using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedNode : MonoBehaviour {

    public static bool UpdateList;
    public static bool change;
    private Image MyImage;
    private GenericListLoader MyGenericListLoader;
    public static int AssemblyLineNode;// 1, 2 , 3;

    void Start () {
        this.MyGenericListLoader = GetComponent<GenericListLoader>();
        this.MyImage = GetComponent<Image>();
    }

    private void Show(bool showMe)
    {
        this.MyImage.enabled = showMe;
        for (int i = 0; i < this.transform.childCount; i++)
            this.transform.GetChild(i).gameObject.SetActive(showMe);
    }

    void Update () {
            
        if (change == true)
        {
            if (UpdateList == true)
            {
                if (Game.GameInstance.currentSelectedNode != null)
                {
                    if (Game.GameInstance.currentSelectedNode.isCore == true)
                    {
                        this.MyGenericListLoader.elementListType = GenericListLoader.ElementListType.Node_Core;
                    }
                    else if (Game.GameInstance.currentSelectedNode.isCore == false)
                    {
                        this.MyGenericListLoader.elementListType = GenericListLoader.ElementListType.Node_Upgrade;
                    }
                    this.MyGenericListLoader.UpdateList();
                }
                UpdateList = false;
            }
            this.Show(true);
        }
        else
        {
            this.Show(false);
        }

	}

    public void FinishCreation()
    {
        if (Game.GameInstance.currentSelectedNode.MyNode == null)
        {
            if (Game.GameInstance.currentSelectedCoreNode != null)
            {
                if (Game.GameInstance.currentSelectedCoreNode.MyNode.GetType() == typeof(Core))
                {
                    Game.GameInstance.currentSelectedNode.MyNode = DataManager.GetCoreNode(Game.GameInstance.currentSelectedCoreNode.MyNode.node_id, Game.GameInstance.currentSelectedAssemblyLine.MyAssemblyLine.assembly_Line_Id);
                    Game.GameInstance.currentSelectedAssemblyLine.MyAssemblyLine.coreNode = (Core)Game.GameInstance.currentSelectedNode.MyNode;
                    Game.GameInstance.currentSelectedNode.UpdateImage();

                    Game.GameInstance.currentSelectedAssemblyLine.MyAssemblyLine.core_id = Game.GameInstance.currentSelectedNode.MyNode.node_id;
                }
            }

            if (Game.GameInstance.currentSelectedUpgradeNode != null)
            {
                if (Game.GameInstance.currentSelectedUpgradeNode.MyNode.GetType() == typeof(Upgrade))
                {
                    Game.GameInstance.currentSelectedNode.MyNode = DataManager.GetUpgradeNode(Game.GameInstance.currentSelectedUpgradeNode.MyNode.node_id, Game.GameInstance.currentSelectedAssemblyLine.MyAssemblyLine.assembly_Line_Id);
                    Game.GameInstance.currentSelectedAssemblyLine.MyAssemblyLine.Upgrade_Nodes[Game.GameInstance.currentSelectedNode.MyNode.node_id] = (Upgrade)Game.GameInstance.currentSelectedNode.MyNode;
                    Game.GameInstance.currentSelectedNode.UpdateImage();

                    switch (Game.GameInstance.currentSelectedNode.lineIndex)
                    {
                        case 1:
                            Game.GameInstance.currentSelectedAssemblyLine.MyAssemblyLine.upgrade_Node_1 = Game.GameInstance.currentSelectedAssemblyLine.MyAssemblyLine.Upgrade_Nodes[Game.GameInstance.currentSelectedNode.MyNode.node_id].node_id;
                            break;

                        case 2:
                            Game.GameInstance.currentSelectedAssemblyLine.MyAssemblyLine.upgrade_Node_2 = Game.GameInstance.currentSelectedAssemblyLine.MyAssemblyLine.Upgrade_Nodes[Game.GameInstance.currentSelectedNode.MyNode.node_id].node_id;
                            break;

                        case 3:
                            Game.GameInstance.currentSelectedAssemblyLine.MyAssemblyLine.upgrade_Node_3 = Game.GameInstance.currentSelectedAssemblyLine.MyAssemblyLine.Upgrade_Nodes[Game.GameInstance.currentSelectedNode.MyNode.node_id].node_id;
                            break;
                    }
                }
            }

            //Game.GameInstance.currentSelectedAssemblyLine.Nodes[Game.GameInstance.currentSelectedNode.lineIndex].GetComponent<Node>().MyNode = Game.GameInstance.currentSelectedNode.MyNode;
            Game.GameInstance.currentSelectedAssemblyLine.initializeNodes();

        }
        else
        {
            Debug.Log("El espacio no estaba vacio");
            
        }

        Game.GameInstance.currentSelectedNode = null;
        Game.GameInstance.currentSelectedCoreNode = null;
        Game.GameInstance.currentSelectedUpgradeNode = null;
        Game.GameInstance.currentSelectedAssemblyLine = null;
        change = false;


        /*
        if (Game.GameInstance.currentSelectedCoreNode == null)
        {
            Debug.Log("Core Nulo");
        }

        if (Game.GameInstance.currentSelectedAssemblyLine == null)
        {
            Debug.Log("Assembly Line Nulo");
        }

        if ((Game.GameInstance.currentSelectedCoreNode != null || Game.GameInstance.currentSelectedUpgradeNode != null)
            && Game.GameInstance.currentSelectedAssemblyLine != null)
        {

            if (Game.GameInstance.currentSelectedNode.GetType() == typeof(Core))
            {
                Game.GameInstance.currentSelectedAssemblyLine.coreNode = Game.GameInstance.currentSelectedCoreNode;
            }
            else if (Game.GameInstance.currentSelectedNode.GetType() == typeof(Upgrade))
            {
                Game.GameInstance.currentSelectedAssemblyLine.upgrade_Node_1 = Game.GameInstance.currentSelectedUpgradeNode.node_id;
            }

            Debug.Log("Nodo Acoplado");
            Game.GameInstance.currentSelectedAssemblyLine = null;
            Game.GameInstance.currentSelectedNode = null;
            Game.GameInstance.currentSelectedUpgradeNode = null;
            //Show(false);

        }
        */
    }

    public void CancelOperation()
    {
        SelectedNode.change = false;
        Game.GameInstance.currentSelectedNode = null;
        Game.GameInstance.currentSelectedCoreNode = null;
        Game.GameInstance.currentSelectedAssemblyLine = null;
    }

}
