using UnityEngine;
using System.Collections;

public class EnemyMelee_PlayerFXCall : MonoBehaviour {

	//this is attached to FX on the player to shw a Melee hit
	public float randomDistance = 4;
	public float heightOffset = 6;
	public Vector3 randomPos;
	public ParticleSystem thisParticles;

	IEnumerator EndParticalPlay ()
	{
		yield return new WaitForSeconds (0.01f);
		thisParticles.Stop();
	}

	void AddDamage (float _f)
	{
		randomPos.x = Random.Range (randomDistance * -1, randomDistance);
		randomPos.y = Random.Range (0, randomDistance) + heightOffset;  
		this.transform.localPosition = randomPos;
		thisParticles.Play();
		StartCoroutine (EndParticalPlay ());
	}
	
	void Start () {
		EnemyMeleeOnAnimator.MeleeEvent += AddDamage;
	}
}
