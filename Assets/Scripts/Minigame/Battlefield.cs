using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour {

    private DataMision MisionSelected;
    public GameObject UnknownEnemy;

	void Start () {
        MisionSelected = GameManager.Instance.CurrentSelectedMission;

        for(int i = 0; i < MisionSelected.EnemiesQnty; i++)
        {
            GameObject enemUnknown = Instantiate(UnknownEnemy);
            enemUnknown.SetActive(true);
            enemUnknown.transform.SetParent(UnknownEnemy.transform.parent, false);
        }

	}
	
}
