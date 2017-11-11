using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenericPanelTemplate : MonoBehaviour {

    public Text Name;
    public Text Description;
    public Text Cant; //Extracted/Remaining;

    private void Start()
    {

    }

    public void SearchInfo()
    {
        //Se obtiene el objeto que seleccionado
        GameObject genericGameobject = EventSystem.current.currentSelectedGameObject;//Robot, Nodo, Extractor, etc
        string genericGoID = "Empty";
        if (genericGameobject != null)
        {
            switch (genericGameobject.GetComponent<TemplateType>().Type)
            {
                case TemplateType.TemplateTypeEx.AssemblyLine:
                    //genericGoID = genericGameobject.GetComponent<AssemlbyLineTemplate>();
                    break;

                case TemplateType.TemplateTypeEx.Extractor:
                    genericGoID = genericGameobject.GetComponent<ExtractorTemplate>().MyExtractor.Id;
                    Debug.Log("GenereicName " + genericGameobject.GetComponent<ExtractorTemplate>().name);
                    Debug.Log("ID = " + genericGoID);
                    //Lo busco 
                    //current SearchObject<>
                    UpdateData(genericGameobject.GetComponent<ExtractorTemplate>());
                    //CurrentObject = SarchObject<Extractor>(genericGoID);
                    break;

                case TemplateType.TemplateTypeEx.Mision:
                    //genericGoID = genericGameobject.GetComponent<MisionTemplate>();
                    genericGoID = genericGameobject.GetComponent<MisionTemplate>().MyMision.Id;
                    Debug.Log("GenericName " + genericGameobject.GetComponent<MisionTemplate>().MyMision.Id);
                    UpdateData(genericGameobject.GetComponent<MisionTemplate>());
                    GameManager.Instance.CurrentSelectedMission = genericGameobject.GetComponent<MisionTemplate>().MyMision;
                    break;

                case TemplateType.TemplateTypeEx.Robot:
                    genericGoID = genericGameobject.GetComponent<RobotTemplate>().MyRobot.RobotID;
                    Debug.Log("GenericName " + genericGameobject.GetComponent<RobotTemplate>().robotName);
                    UpdateData(genericGameobject.GetComponent<RobotTemplate>());
                    break;
            }
        }
        else
        {
            Debug.Log("ganericGameObject Nulo");
        }
        //RobotId.text = currentExtractor.RobotID;
        //RobotCant.text = "" + currentExtractor.RobotCant;
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
