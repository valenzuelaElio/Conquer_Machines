using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGo : MonoBehaviour {

    public EnemyGo firstEnemyOnLine;
    private DataRobot myRobot;
    public DataRobot MyRobot {
        get { return this.myRobot; }
        set { this.myRobot = value; } }

    public LayerMask layerMask;
    public bool isAttacking;

    public enum RobotState
    {
        Walking,
        DoNothing,
        Attacking,
        Standby
    }
    private RobotState myState;
    public RobotState MyActualState { get { return myState; } set { myState = value; } }

    int myLifePoints;

	void Start () {
        myState = RobotState.Walking;
        myLifePoints = myRobot.LifePoints;
    }
	
	void Update () {
		if(this.myLifePoints <= 0)
        {
            Destroy(this.gameObject);
        }

        switch (myState)
        {
            case RobotState.Attacking:
                isAttacking = true;
                myState = RobotState.Standby;
                break;
            case RobotState.DoNothing: break;
            case RobotState.Walking: Walk(); break;
            case RobotState.Standby:
                if (isAttacking == false)
                {
                    myState = RobotState.Walking;
                }
                break;

        }

        if(myState != RobotState.Standby)
        {
            isAttacking = false;
        }

        if(firstEnemyOnLine == null)
        {
            myState = RobotState.Walking;
        }


	}

    public void setRobotType(DataRobot robot)
    {
        this.myRobot = robot;
    }

    public void GetDamaged(int damage)
    {
        myLifePoints -= damage;
    }

    private void Walk()
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.left);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction, 0.8f,layerMask);
        Debug.DrawRay(ray.origin, ray.direction);
            
        if (raycastHit2D.collider != null) //Si choque con algo?
        {
            Debug.Log(raycastHit2D.collider.name);
            firstEnemyOnLine = raycastHit2D.collider.GetComponent<EnemyGo>();
            myState = RobotState.Attacking;
        }
        else
        {
            transform.Translate(Vector2.left * 0.5f * Time.deltaTime);
        }
    }
}
