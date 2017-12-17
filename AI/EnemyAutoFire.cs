using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAutoFire : MonoBehaviour {
	
	private int i = 0;
	public Animator EnemyAnimation;
	public Transform ammoStart;
	public EnemyWeaponFX[] enemyAmmo;
	public List<EnemyWeaponFX> enemyAmmoList;


	void StartAmmo (EnemyWeaponFX obj)
	{
		enemyAmmoList.Add(obj);
		EnemyAnimation.SetBool("Fire", true);
	}

	void AddAllToList ()
	{
		foreach (EnemyWeaponFX _e in enemyAmmo) {
			enemyAmmoList.Add(_e);
		}
	}

	void Fire ()
	{
		if (enemyAmmoList.Count > 0) {
			enemyAmmoList [i].transform.position = ammoStart.transform.position;
			enemyAmmoList [i].gameObject.SetActive (true);
			enemyAmmoList.RemoveAt (0);
		} else {
			EnemyAnimation.SetBool("Fire", false);
		}
	}

	void Awake () {
		enemyAmmoList = new List<EnemyWeaponFX> ();
		AddAllToList ();
		foreach (EnemyWeaponFX _e in enemyAmmoList) {
			_e.ResetAmmo += StartAmmo;
		}
	}

	void OnMouseDown () 
	{
		Fire ();
	}
}
