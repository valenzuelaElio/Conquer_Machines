using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExtractionPanelInfo : MonoBehaviour {

    private Object CurrentObject;
    public Text RobotId;
    public Text RobotCant;

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
                    if (genericGameobject.GetComponent<ExtractorTemplate>() != null)
                    {
                        if (genericGameobject.GetComponent<ExtractorTemplate>().MyExtractor != null)
                        {
                            genericGoID = genericGameobject.GetComponent<ExtractorTemplate>().MyExtractor.Id;
                            Debug.Log("ID = " + genericGoID);
                        }
                        else
                        {
                            Debug.Log("MyExtractor nulo");
                        }
                    }
                    else
                    {
                        Debug.Log("Componente nulo");
                    }
                    //CurrentObject = SarchObject<Extractor>(genericGoID);
                    break;

                case TemplateType.TemplateTypeEx.Mision:
                    //genericGoID = genericGameobject.GetComponent<MisionTemplate>();
                    break;

                case TemplateType.TemplateTypeEx.Robot:
                    //genericGoID = genericGameobject.GetComponent<RobotTemplate>();
                    break;
            }
        }
        else
        {
            Debug.Log("GameObject es nulo");
        }
        


        //RobotId.text = currentExtractor.RobotID;
        //RobotCant.text = "" + currentExtractor.RobotCant;
    }

         // T == El objeto que retorna "T" puede ser cualquiera.
         //
    public T SearchObject<T>(string id)
    {
        //Object typeOfList = new Object();
        //typeOfList[] list = 
        //Object[] Itemslist = Game.Instance.GameData.Extractors;

        //foreach (T temp in listLoader.GenericList)
        //{
            //if (temp.Id.Equals(id))   
            //{
            //    return temp;
           // }
        //}
        Debug.LogError("No se encontro al extractor");
        return default(T);
    }
}
