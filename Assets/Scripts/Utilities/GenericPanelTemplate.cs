using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenericPanelTemplate : MonoBehaviour {
    public Text Name;
    public Text Description;
    public Text Cant; //Extracted/Remaining;

    GenericListController glc;

    public void ShowInfo()
    {
        if (GenericListController.selected == 0)
        {
            Name.text = "" + Game.GameInstance.currentSelectedRobot.MyRobot.robot_name;
            Description.text = "" + Game.GameInstance.currentSelectedRobot.MyRobot.robot_Description;
            Cant.text = "En Posesion: " + Game.GameInstance.PlayerInstance.RobotQnty[Game.GameInstance.currentSelectedRobot.MyRobot.robot_id];
        }

        if (GenericListController.selected == 1)
        {
            Name.text = "" + Game.GameInstance.currentSelectedNode.MyNode.node_id;
            Description.text = "";
            //Cant.text = "En Posesion: " + Game.GameInstance.PlayerInstance.[Game.GameInstance.currentSelectedRobot.robot_id];
        }

        if (GenericListController.selected == 2)
        {

        }

    }

    private void Update()
    {
        SearchInfo();
    }

    public void SearchInfo()
    {
        //Se obtiene el objeto que seleccionado
        GameObject genericGameobject = EventSystem.current.currentSelectedGameObject;//Robot, Nodo, Extractor, etc
        if (genericGameobject != null)
        {
            if (genericGameobject.GetComponent<TemplateType>() == null)
            {
                return;
            }

            switch (genericGameobject.GetComponent<TemplateType>().Type)
            {
                case TemplateType.TemplateTypeEx.AssemblyLine:
                    break;

                case TemplateType.TemplateTypeEx.Extractor:
                    UpdateData(genericGameobject.GetComponent<Extractor>());
                    break;

                case TemplateType.TemplateTypeEx.Mision:
                    UpdateData(genericGameobject.GetComponent<Mision>());
                    //GameManager.Instance.CurrentSelectedMission = genericGameobject.GetComponent<Mision>().MyMision;
                    break;

                case TemplateType.TemplateTypeEx.Robot:
                    UpdateData(genericGameobject.GetComponent<Robot>());
                    break;

                case TemplateType.TemplateTypeEx.Node:
                    UpdateData(genericGameobject.GetComponent<Node>());
                    break;

                case TemplateType.TemplateTypeEx.RawMaterial:
                    UpdateData(genericGameobject.GetComponent<RawMaterial>());
                    break;
            }
        }
        else
        {
            Debug.Log("ganericGameObject Nulo");
        }
    }

    void UpdateData(ITemplate GenericTemplate)
    {
        if (Name != null)
        {
            this.Name.text = GenericTemplate.Id();
        }

        if (Description != null)
        {
            this.Description.text = GenericTemplate.Description();
        }

        if (Cant != null)
        {
            this.Cant.text = "" + GenericTemplate.Cant();
        }
    }
}
