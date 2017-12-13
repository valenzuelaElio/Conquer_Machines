using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject battleRobot;
    DataEnemy MyEnemy = new DataEnemy();

    const int damageSpeedConstant = 100;
    int damageOfTheRobot = 0;
    float damageSpeed = 0;

    float startTime;
    float timeStamp;

    public int LifePoints;
    int distance = 10;
    public GameObject projectilGenerator;
    public LayerMask layerMask;
    public enum EnemyState
    {
        DoNothing,
        Attack,
        Looking,
        Attacked,
        StandBy
    }
    private EnemyState enemyState;

	void Start () {
        //TODO: Esta informacion deberia ser dada medinate una plantilla.

        enemyState = EnemyState.Looking;
        Attack(true);
        startTime = 0;

        this.MyEnemy.LifePoints = 100;
        this.MyEnemy.Attack = 10;
        this.MyEnemy.Defense = 10;
        this.MyEnemy.Speed = 10;

        this.LifePoints = this.MyEnemy.LifePoints;

        EnemyGenerator.EnemiesOnMap.Add(this);
    }

    void Update () {

        switch (enemyState)
        {
            case EnemyState.Attack: Attack(true); Looking(); break;
            case EnemyState.DoNothing: break;
            case EnemyState.Looking: Looking(); break;

            case EnemyState.Attacked:
                VerifyLifePoints();
                break;
        }
	}

    private void VerifyLifePoints()
    {
        if (this.LifePoints <= 0 )
        {
            this.battleRobot.SendMessage("Target", null);
            EnemyGenerator.RemoveEnemy(this);
            Debug.Log("Size = " + EnemyGenerator.EnemiesOnMap.Count);
            Destroy(this.gameObject);
        }
    }

    private void ReceiveDamage(int damage)
    {
        this.LifePoints -= damage;
        //Debug.Log("Life " + this.LifePoints);
    }

    private void Attack(bool b)
    {
        projectilGenerator.GetComponent<ProjectilGenerator>().StartToGen = b;
    }

    private void Looking()
    {
        Ray ray = new Ray(this.gameObject.transform.position, Vector3.right);
        RaycastHit2D rayHit = Physics2D.Raycast(ray.origin, ray.direction, 10, layerMask);

        //Debug.Log("Distance = " + rayHit.distance);
        Debug.DrawRay(ray.origin, ray.direction);

        if(rayHit.collider != null && rayHit.collider.tag == "Robot")
        {
            //Debug.Log("Colision con algo" + rayHit.distance);
            enemyState = EnemyState.Attack;

            //if (rayHit.collider.GetComponent<BattleRobot>().isAttacking)
            //{
                //if(rayHit.collider.GetComponent<BattleRobot>().firstEnemyOnLine == this)

                //if (lifePoints <= 0)
                //{
                    //rayHit.collider.GetComponent<BattleRobot>().isAttacking = false;
                   // Destroy(gameObject);
                    //EnemyGenerator.Instance.CheckMap();
                //}
            //}


        } else
        {
            Attack(false);
        }
        

    }

    void ReceiveDamage(bool b)
    {
        if (b == true)
        {
            this.enemyState = EnemyState.Attacked;
        }
        else
        {
            this.enemyState = EnemyState.StandBy;
        }
        //Debug.Log("Cambie a " + b);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BattleRobot>() != null)
        {
            collision.gameObject.SendMessage("Target", this.gameObject);
            this.battleRobot = collision.gameObject;
        }

    }

}
