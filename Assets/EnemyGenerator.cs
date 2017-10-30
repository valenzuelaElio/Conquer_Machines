using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public GameObject enemyTamplate;
    public GameObject GridMap;
    private List<GameObject> emptySpaces;

	// Use this for initialization
	void Start () {

        Random random = new Random();
        for(int i = 0; i < 6; i++)
        {
            Transform t = GridMap.transform.GetChild(Random.Range(0, 5) * 8); // TODO: Mejorar creacion de enemigos; 

            if (t.childCount == 0)
            {
                GameObject go = Instantiate(enemyTamplate, t.position, gameObject.transform.rotation) as GameObject;
                go.transform.SetParent(t);
            }


        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
