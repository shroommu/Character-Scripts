using UnityEngine;

[CreateAssetMenu(fileName = "BoolInput")]
public class BoolInput : InputBase
{
	public string InputName = "Jump";
	public float FloatValue = 1;
	
	public override float SetFloat()
	{
		return Input.GetButton(InputName) ? FloatValue : 0;
	}
}