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
    public static List<EnemyGo> EnemiesOnMap = new List<EnemyGo>();
    private DataMision CurrentMission;

    //TODO Una lista de posibles enemigos cargada desde la base de datos;

	void Start () {
        CurrentMission = Game.GameInstance.currentSelectedMision;
        for(int i = 0; i < CurrentMission.EnemiesQnty; i++)
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
                ScenesManager.GoToScene(Game.GameInstance.GameData.ScenesNames[4]);
                break;
        }
    }

    public void CheckMap()
    {
        //for (int i = 0; i < GridMap.transform.childCount; i++)
        //{
        //    Transform t = GridMap.transform.GetChild(i);
        //    if (t.GetChild(i) != null && t.tag == "Enemy")
        //    {
        //        //Si ya no hay mas enemigos en la escena
        //        //Por ahora el objetivo es acabar con todos los robots;
        //        return;
        //   }
        //    else
        //   {
        //        ActualState = BattleState.GameOver;
        //    }
        //}

        if(EnemiesOnMap.Count > 0)
        {
            return;
        }
        else
        {
            ActualState = BattleState.GameOver;
        }

    }

}
