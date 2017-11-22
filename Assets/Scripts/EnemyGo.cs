using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGo : MonoBehaviour {

    float startTime;
    float timeStamp;
    int lifePoints;
    int distance = 10;
    public GameObject projectilGenerator;
    public LayerMask layerMask;
    public enum EnemyState
    {
        DoNothing,
        Attack,
        Looking
    }
    private EnemyState enemyState;

	void Start () {
        //TODO: Esta informacion deberia ser dada medinate una plantilla.

        enemyState = EnemyState.Looking;
        Attack(true);
        lifePoints = 100;
        startTime = 0;

        EnemyGenerator.EnemiesOnMap.Add(this);
    }

    void Update () {

        switch (enemyState)
        {
            case EnemyState.Attack: Attack(true); Looking(); break;
            case EnemyState.DoNothing: break;
            case EnemyState.Looking: Looking(); break;
        }
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
            Debug.Log("Colision con algo" + rayHit.distance);
            enemyState = EnemyState.Attack;

            if (rayHit.collider.GetComponent<RobotGo>().isAttacking)
            {
                if(rayHit.collider.GetComponent<RobotGo>().firstEnemyOnLine == this)
                ReceiveDamage(
                    rayHit.collider.GetComponent<RobotGo>().MyRobot.Attack,
                    rayHit.collider.GetComponent<RobotGo>().MyRobot.Speed);

                if (lifePoints <= 0)
                {
                    rayHit.collider.GetComponent<RobotGo>().isAttacking = false;
                    Destroy(gameObject);
                    EnemyGenerator.Instance.CheckMap();
                }
            }


        } else
        {
            Attack(false);
        }
        

    }

    void ReceiveDamage(int damage, float attackSpeed)
    {
        this.timeStamp = Time.time - this.startTime;
        if (this.timeStamp >= attackSpeed)
        {
            this.lifePoints -= damage;
            this.startTime = Time.time;
        }

        //Debug.Log("Damage" + damage);
        //Debug.Log("StartTime " + startTime);
        //Debug.Log("Timestamp " + timeStamp);
        //Debug.Log("Enemy h = " + lifePoints);

        
    }

}
