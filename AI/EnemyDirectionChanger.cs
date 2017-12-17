using UnityEngine;
using System.Collections;

public class EnemyDirectionChanger : MonoBehaviour {

	public float enemyTurnDelay = 1;//The amount of time it takes for an enemy to turn around and attack
	const int i = 180;//the rotation amount of this gameObject

	public Transform EnemyArtControl;//the gameObject that can rotate the art asset


	IEnumerator TurnEnemyWithDelay ()
	{
		yield return new WaitForSeconds(enemyTurnDelay);
		EnemyArtControl.Rotate (0, i, 0);//rotates the AI 180 in Y to "chase" the Player
	}

	
	void OnTriggerEnter ( ) {
		StartCoroutine(TurnEnemyWithDelay ());//starts a delay
	}
}
