using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractorPanel : MonoBehaviour {

    private Extractor[] AllExtractors;
    public GameObject ExtractorTemplate;

	void Start () {

        AllExtractors = GameState.Instance.GameData.Extractors;

        for (int i = 0; i < AllExtractors.Length; i++)
        {
            GameObject robot = Instantiate(ExtractorTemplate) as GameObject;
            robot.SetActive(true);

            robot.GetComponent<ExtractorTemplate>().id.text = AllExtractors[i].Id;

            robot.transform.SetParent(ExtractorTemplate.transform.parent, false);
        }
    }
	
	void Update () {
		
	}
}
