using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemyWeaponFX : EffectSettings {


	//and extention of the Effects Settings class as part of the Realistic FX Packs
	public float ammoPower = 0.1f;
	public Action<EnemyWeaponFX> ResetAmmo;//a delegate that sends it's settings to the player's health


	public override void OnEffectDeactivatedHandler ()
	{
		base.OnEffectDeactivatedHandler ();

			if (ResetAmmo != null) {
				ResetAmmo (this);
		}
	}

	//waits to load into the game to add Action subscribers, then deactivates
	public IEnumerator StartLate () {
		yield return new WaitForSeconds (0.01f);
		this.gameObject.SetActive (false);
	}

	public virtual void Start () {
		StartCoroutine (StartLate ());
	}
	
}
