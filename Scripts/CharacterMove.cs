using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By Anthony Romrell
public class CharacterMove : MonoBehaviour 
{
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection;
	private Vector3 rotateDirection;

	private CharacterController controller;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update() {
		if (controller.isGrounded)
		{
			//rotateDirection.y = Input.GetAxis("Horizontal");
			transform.Rotate(rotateDirection);
			moveDirection.Set(Input.GetAxis("Horizontal"), 0, 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
            
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}	
}