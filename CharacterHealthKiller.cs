using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CharacterHealthKiller : MonoBehaviour {

	public float ammoPower = 0.1f;
	public static UnityAction<float> UpdateHealth;
	public static UnityAction<int> CoinPowerDown;

	void OnTriggerEnter (Collider _collider)
	{
		if(_collider.tag == "Player") {
			if(UpdateHealth != null) {
				UpdateHealth(ammoPower);
				CoinPowerDown((int)ammoPower);
			}
		}
	}
}
