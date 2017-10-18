using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MisionInfoPanel : MonoBehaviour {

    private Mision CurrentMisionInfo;

    public Text MisionName;
    public Text MisionDescription;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

	}

    public void SearchInfo()
    {
        string id = EventSystem.current.currentSelectedGameObject.GetComponent<MisionTemplate>().misionName.text;
        Debug.Log("ID = " + id);

        CurrentMisionInfo = SearchMission(id);

        MisionName.text = CurrentMisionInfo.Id;
        MisionDescription.text = CurrentMisionInfo.Description;

    } 

    Mision SearchMission(string id)
    {
        Mision[] misionList = GameState.Instance.GameData.Misions;
        foreach (Mision temp in misionList)
        {
            if (temp.Id.Equals(id))
            {
                return CurrentMisionInfo = temp;
            }
                    }
        Debug.LogError("No se encontro la mision");
        return misionList[0];

    }

}
