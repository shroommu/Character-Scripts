using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PatternNotGrounded")]
public class MovePatternNotGrounded : MovePatternBase
{
	public MovePatternBase MovePattern;

	public override void Move(CharacterController controller, Transform transform)
	{
		MovePattern.Move(controller, transform);
		
		//moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}