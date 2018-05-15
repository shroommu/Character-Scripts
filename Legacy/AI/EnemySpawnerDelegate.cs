using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemySpawnerDelegate : MonoBehaviour
{
	bool canSpawn = false;
    public float randomSpawningTime = 10;//variation on respawn time
	public static Action<Vector3> ActivateEnemyEvent; //invokes the delegate

    void OnTriggerEnter()
    {
		canSpawn = true;
    	StartCoroutine (ActivateEnemy()); //runs the enemy activation event
    }

	void OnTriggerExit()
    {
    	canSpawn = false;
    }

    IEnumerator ActivateEnemy()
    {
		while (canSpawn)
		{
			yield return new WaitForSeconds(UnityEngine.Random.Range(0, randomSpawningTime));
			if (ActivateEnemyEvent != null)
            {
                ActivateEnemyEvent(transform.position);//passes this postion to any 
            }
		}
	}
}