using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMovement : ScriptableObject
{
	
	//public float Speed;
	public abstract CharacterController MyCharacterController { set ;}
	public abstract Animator MyAnimator {set ;}
	
	public abstract void LeftHander();
	public abstract void RightHander();
	public abstract void UpHander();
	public abstract void DownHander();
	public abstract void SpaceHander();

	public abstract IEnumerator Jump();
	public abstract void Move(float speed);

}