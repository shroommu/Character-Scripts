using UnityEngine;

public class ActivateEnemyAI : MonoBehaviour {

	public EnemyController EnemyNavMeshAgent;//instance of EnemyNav script on another game Object

	void OnTriggerStay (Collider _c) {
		EnemyNavMeshAgent.myTarget = _c.gameObject;//changes the navMeshAgent target to the player
		EnemyNavMeshAgent.StartEnemyMove ();
	}

	void OnTriggerExit ( ) {
		EnemyNavMeshAgent.myTarget = this.gameObject;//changes the navMeshAgent target to itself
	}
}
