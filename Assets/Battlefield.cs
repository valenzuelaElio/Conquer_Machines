using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour {

    private Mision MisionSelected;
    public GameObject UnknownEnemy;

	// Use this for initialization
	void Start () {
        MisionSelected = GameManager.Instance.CurrentSelectedMission;

        for(int i = 0; i < MisionSelected.EnemiesQuant; i++)
        {
            GameObject enemUnknown = Instantiate(UnknownEnemy);
            enemUnknown.SetActive(true);
            enemUnknown.transform.SetParent(UnknownEnemy.transform.parent, false);
        }

	}
	
	// Update is called once per frame
	void Update () {

	}
}
