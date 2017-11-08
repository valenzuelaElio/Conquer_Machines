using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public GameObject enemyTamplate;
    public GameObject GridMap;
    private List<GameObject> emptySpaces;

    //TODO Una lista de posibles enemigos cargada desde la base de datos;

	void Start () {

        Random random = new Random();
        for(int i = 0; i < 15; i++)
        {
            Transform t = GridMap.transform.GetChild(i); // TODO: Mejorar creacion de enemigos; 

            if (t.childCount == 0)
            {
                GameObject go = Instantiate(enemyTamplate, t.position, gameObject.transform.rotation) as GameObject;
                go.transform.SetParent(t);
            }


        }

		
	}
}
