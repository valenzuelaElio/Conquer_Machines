using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericListLoader : MonoBehaviour {

    
    public enum ElementListType
    {
        Extractors,
        Robots,
        Misions,
        AssemblyLine,
        
    }
    public ElementListType elementListType;
    public GameObject ItemTemplate;//Esto es lo que deveria instanciarse en la pantalla.
    public object[] GenericList;

    void Start () {
        //Con esto se inicializa la informacion;
        SelectType();
        //GenericList = Game.Instance.GameData.Extractors;
        Debug.Log("Size = " + GenericList.Length);
        for (int i = 0; i < GenericList.Length; i++)
        {
            //ItemTemplate.GetComponent<GenericTemplate>();
            //obj.GetComponent<>().id.text = GenericList[i].Id;
            switch (elementListType)
            {
                //case ElementListType.AssemblyLine: break;
                case ElementListType.Extractors:
                    ItemTemplate.GetComponent<ExtractorTemplate>().MyExtractor = (Extractor)GenericList[i];
                    Debug.Log(ItemTemplate.GetComponent<ExtractorTemplate>().MyExtractor.Id);
                    ItemTemplate.GetComponent<ExtractorTemplate>().ShowData();
                    break;
            }
            GameObject obj = Instantiate(ItemTemplate) as GameObject;
            obj.SetActive(true);

            obj.transform.SetParent(ItemTemplate.transform.parent, false);
        }
    }

    void SelectType()
    {
        switch (elementListType)
        {
            case ElementListType.AssemblyLine: GenericList = Game.Instance.GameData.AssemblyLines; break;
            case ElementListType.Extractors: GenericList = Game.Instance.GameData.Extractors; break;
            case ElementListType.Misions: GenericList = Game.Instance.GameData.Misions; break;
            case ElementListType.Robots: GenericList = Game.Instance.GameData.Robots; break;
        }
    }

}
