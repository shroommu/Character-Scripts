using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePatternWithIsGrounded : MovePatternBase
{

	public MovePatternBase MovePattern;
	
	public override void Move(CharacterController controller, Transform transform)
	{
		if (controller.isGrounded)
		{
			MovePattern.Move(controller, transform);
		}
		
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
