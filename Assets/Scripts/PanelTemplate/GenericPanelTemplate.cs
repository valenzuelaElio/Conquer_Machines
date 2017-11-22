using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenericPanelTemplate : MonoBehaviour {
    public Text[] TextInformation;

    public Text Name;
    public Text Description;
    public Text Cant; //Extracted/Remaining;

    public void SearchInfo()
    {
        //Se obtiene el objeto que seleccionado
        GameObject genericGameobject = EventSystem.current.currentSelectedGameObject;//Robot, Nodo, Extractor, etc
        if (genericGameobject != null)
        {
            switch (genericGameobject.GetComponent<TemplateType>().Type)
            {
                case TemplateType.TemplateTypeEx.AssemblyLine:
                    break;

                case TemplateType.TemplateTypeEx.Extractor:
                    UpdateData(genericGameobject.GetComponent<Extractor>());
                    break;

                case TemplateType.TemplateTypeEx.Mision:
                    UpdateData(genericGameobject.GetComponent<Mision>());
                    GameManager.Instance.CurrentSelectedMission = genericGameobject.GetComponent<Mision>().MyMision;
                    break;

                case TemplateType.TemplateTypeEx.Robot:
                    UpdateData(genericGameobject.GetComponent<Robot>());
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
