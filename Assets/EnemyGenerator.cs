using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviourSingleton<EnemyGenerator> {

    //TODO: Generar una lista de enemigos en la base de datos;

    public enum BattleState
    {
        Starting,
        InBattle,
        GameOver,
    }
    private BattleState ActualState { get; set; }

    public GameObject enemyTamplate;
    public GameObject GridMap;
    private List<GameObject> emptySpaces;

    //TODO Una lista de posibles enemigos cargada desde la base de datos;

	void Start () {

        Random random = new Random();
        for(int i = 0; i < 1; i++)
        {
            Transform t = GridMap.transform.GetChild(i); // TODO: Mejorar creacion de enemigos; 

            if (t.childCount == 0)
            {
                GameObject go = Instantiate(enemyTamplate, t.position, gameObject.transform.rotation) as GameObject;
                go.transform.SetParent(t);
            }
        }
	}

    void Update()
    {
        switch (ActualState)
        {
            case BattleState.GameOver:

                Game.Instance.LoadScene(Game.Instance.GameData.ScenesNames[3]);

                break;
        }
    }

    public void CheckMap()
    {
        for (int i = 0; i < GridMap.transform.childCount; i++)
        {
            Transform t = GridMap.transform.GetChild(i);
            if (t.GetChild(i) != null && t.tag == "Enemy")
            {
                //Si ya no hay mas enemigos en la escena
                //Por ahora el objetivo es acabar con todos los robots;
                return;
            }
            else
            {
                ActualState = BattleState.GameOver;
            }
        }
    }

}
