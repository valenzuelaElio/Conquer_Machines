using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExtractionPanelInfo : MonoBehaviour {

    private Extractor currentExtractor;

    public Text RobotId;
    public Text RobotCant;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SearchInfo()
    {
        string id = EventSystem.current.currentSelectedGameObject.GetComponent<ExtractorTemplate>().id.text;
        Debug.Log("ID = " + id);

        currentExtractor = SearchExtractor(id);

        RobotId.text = currentExtractor.RobotID;
        RobotCant.text = "" + currentExtractor.RobotCant;
    }

    Extractor SearchExtractor(string id)
    {
        Extractor[] extractorList = GameState.Instance.GameData.Extractors;
        foreach (Extractor temp in extractorList)
        {
            if (temp.Id.Equals(id))
            {
                return temp;
            }
        }
        Debug.LogError("No se encontro al extractor");
        return extractorList[0];
    }
}
