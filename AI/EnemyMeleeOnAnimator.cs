using UnityEngine;
using System.Collections;
using System;

public class EnemyMeleeOnAnimator : MonoBehaviour {

	public float killPower = 0.1f;

	public static Action<float> MeleeEvent;

	//This runs on a enemy melee animation
	void OnMelee () {
		if (MeleeEvent != null) {
			MeleeEvent(killPower);
		}
	}
}
