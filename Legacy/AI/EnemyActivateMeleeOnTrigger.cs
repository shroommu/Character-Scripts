using UnityEngine;
using System.Collections;

public class EnemyActivateMeleeOnTrigger : MonoBehaviour {

	//Plays an animation when entering into a player kill trigger to melee
	//requires a box collider is trigger true

	public Animator eAnim;//animator component 
	
	void OnTriggerEnter (Collider _c) {
		if(_c.tag == "Player") {
			eAnim.SetBool ("Melee", true);
		}
	}

	void OnTriggerExit (Collider _c) {
		if(_c.tag == "Player") {
			eAnim.SetBool ("Melee", false);
		}
	}
}
