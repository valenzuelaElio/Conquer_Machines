using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour{

    //TODO: Generar una lista de enemigos en la base de datos;

    public enum BattleState
    {
        Starting,
        InBattle,
        GameOver,
    }
    public static BattleState ActualState { get; set; }

    public GameObject enemyTamplate;
    private List<GameObject> emptySpaces;
    public static List<Enemy> EnemiesOnMap = new List<Enemy>();
    private DataMision CurrentMission;

    //TODO Una lista de posibles enemigos cargada desde la base de datos;

	void Start () {
        ActualState = BattleState.Starting;
        CurrentMission = Game.GameInstance.currentSelectedMision;
        for(int i = 0; i < CurrentMission.EnemiesQnty; i++)
        {
            Transform t = this.gameObject.transform.GetChild(i); // TODO: Mejorar creacion de enemigos; 
            if (t.childCount == 0)
            {
                GameObject go = Instantiate(enemyTamplate, t.position, gameObject.transform.rotation) as GameObject;
                go.transform.SetParent(t);
            }
        }
        ActualState = BattleState.InBattle;
	}

    void Update()
    {
        switch (ActualState)
        {
            case BattleState.GameOver:
                //ScenesManager.GoToScene(Game.GameInstance.GameData.ScenesNames[4]);
                break;
        }
    }

    static public void CheckMap()
    {
        if(EnemiesOnMap.Count > 0)
        {
            return;
        }
        else
        {
            ActualState = BattleState.GameOver;
        }

    }

    public static void RemoveEnemy(Enemy enemy)
    {
        EnemiesOnMap.Remove(enemy);
        CheckMap();
    }

}
