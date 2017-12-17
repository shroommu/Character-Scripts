using UnityEngine;
using System.Collections;
using System;

public class EnemyRetargetCall : MonoBehaviour
{

		public static Action<Transform> UpdateEnemyTargetEvent;

		void StartTarget (float _speed)
		{
				ChangeTarget ();
		}

		IEnumerator IntTarget ()
		{
				yield return new WaitForSeconds (0.1f);
				ChangeTarget ();
		}

		void Start ()
		{
				MoveViaKeys.Speed += StartTarget;
				//MoveViaKeys.Jump += StartTarget;
				StartCoroutine (IntTarget ());
		}
	
		void ChangeTarget ()
		{
				if (UpdateEnemyTargetEvent != null) {
						UpdateEnemyTargetEvent (transform);
				}
		}
}
