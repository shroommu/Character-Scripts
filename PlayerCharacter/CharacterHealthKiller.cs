using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CharacterHealthKiller : MonoBehaviour {

	public float AmmoPower = 0.1f;
	public static UnityAction<float> UpdateHealth;
	public static UnityAction<int> CoinPowerDown;

	void OnTriggerEnter (Collider collider)
	{
		if(collider.tag == "Player") {
			if(UpdateHealth != null) {
				UpdateHealth(AmmoPower);
				CoinPowerDown((int)AmmoPower);
			}
		}
	}
}
