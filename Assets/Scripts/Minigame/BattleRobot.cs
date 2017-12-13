using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobot : MonoBehaviour {

    GameObject enemyCollisioned;

    const int damageSpeedConstant = 100;
    int damageOfTheRobot = 0;
    float damageSpeed = 0;

    float startTime;
    float timeStamp;

    public DataRobot MyRobot { get; set; }
    public Enemy firstEnemyOnLine;

    public enum RobotState { Walking, Attacking, Standby, }
    public RobotState MyActualState { get; set; }

    private float MyLifePoints;
	void Start () {
        MyActualState = RobotState.Walking;
        MyLifePoints = this.MyRobot.LifePoints;
    }
	
	void Update () {
        switch (MyActualState)
        {
            case RobotState.Attacking:  DamageEnemy(); VerifyEnemy();break;
            case RobotState.Walking:    Walk(Vector3.left); break;
            case RobotState.Standby:    break;
        }
	}
    
    private void VerifyEnemy()
    {
        if (enemyCollisioned != null)
        {
            return;
        }
        else
        {
            MyActualState = RobotState.Walking;
        }
    }

    private void Walk(Vector3 directions)
    {
        this.transform.Translate(directions * this.MyRobot.Speed * Time.deltaTime);
    }

    private void ReceiveDamage(float damage)
    {
        this.MyLifePoints -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            float projectileDamage = collision.gameObject.GetComponent<Projectile>().Damage;
            ReceiveDamage( projectileDamage );
        }

        if (collision.gameObject.tag != "Enemy")
        {
            if (MyActualState != RobotState.Attacking) {
                MyActualState = RobotState.Walking;
            }
            //Walk(Vector3.left); //Movimiento base hacia la izquierda.
            //Me sigo moviendo hasta encontrar un enemigo
            //Si lo encuentro cambio a modo de ataque
        }
        else
        {
            //Debug.Log("Choque con " + collision.gameObject.name);
            //collision.gameObject.SendMessage("SetRobotSpeed",this.MyRobot.Speed + 100);
            //collision.gameObject.SendMessage("SetRobotAttack",this.MyRobot.Attack);
            MyActualState = RobotState.Attacking;
            SetRobotAttack(this.MyRobot.Attack);
            SetRobotSpeed(this.MyRobot.Speed);
            this.enemyCollisioned = collision.gameObject;

            //MyActualState = RobotState.Standby;
        }
    }

    private void DamageEnemy()
    {
        if (this.enemyCollisioned != null)
        {
            //Debug.Log("Sigo Chocando con " + collision.gameObject.name);
            //Comienzo a quitarle vida al enemigo

            this.timeStamp = Time.time - this.startTime;
            if (timeStamp >= damageSpeed)
            {
                enemyCollisioned.gameObject.SendMessage("ReceiveDamage", true);//Le digo al enemigo que le estoy haciendo da♫o
                enemyCollisioned.gameObject.SendMessage("ReceiveDamage", damageOfTheRobot);

                startTime = Time.time;

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            //Comienzo a caminar otra vez
            if (this.enemyCollisioned == null)
            {
                MyActualState = RobotState.Walking;
            }
        }
        else
        {
            //Debug.Log("Deje de chocar con " + collision.gameObject.name);
        }
    }

    void SetRobotSpeed(float robotSpeed)
    {
        damageSpeed = damageSpeedConstant / robotSpeed; //Siendo 20 la velocidad base de un robot golpearia cada 5 seg;
        Debug.Log("SetRobotSpeed " + damageSpeed);
    }

    void SetRobotAttack(int robotAttack)
    {
        damageOfTheRobot = robotAttack;
        if (damageOfTheRobot <= 0)
            damageOfTheRobot = 10;

        Debug.Log("SetRobotAttack " + damageOfTheRobot);
    }

    public void Target(GameObject Enemy)
    {
        this.enemyCollisioned = Enemy;
    }
}
