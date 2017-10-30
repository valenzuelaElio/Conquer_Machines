using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

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
        enemyState = EnemyState.Looking;
	}
	
	void Update () {

        switch (enemyState)
        {
            case EnemyState.Attack: Attack(true); break;
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
        distance += 10;
        Attack(false);

        Ray ray = new Ray(this.gameObject.transform.position, Vector3.right);
        RaycastHit2D rayHit = Physics2D.Raycast(ray.origin, ray.direction, 10, layerMask);

        //Debug.Log("Distance = " + rayHit.distance);
        Debug.DrawRay(ray.origin, ray.direction);

        if(rayHit.collider != null && rayHit.collider.tag == "Robot")
        {
            //Debug.Log("Colision con algo" + rayHit.distance);
            enemyState = EnemyState.Attack;
        }

    }
}
