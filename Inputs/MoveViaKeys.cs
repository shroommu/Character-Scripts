using UnityEngine;
using System.Collections;
using System;

public class MoveViaKeys : MonoBehaviour
{
    //Events
    public static Action<float> Speed;
    public static Action Jump;
    public static Action<float> Direction;
    
    //Properties
    private CharacterController _myController;
    public Animator CharacterAnim;
    public MoveAndJumpAndFloatCharacter MyMoveAndJumpAndFloatCharacter;
    
    
    
    //Methods
    void Start()
    {
        EndGame.TurnOffGame += DisableScript;
        _myController = GetComponent<CharacterController>();
    }

    void DisableScript()
    {
        this.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Direction != null)
        {
            Direction(180);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Direction != null)
        {
            Direction(0);
        }

        if (Speed != null)
            MyMoveAndJumpAndFloatCharacter.MoveCharacter(Input.GetAxis("Horizontal"), _myController);
            Speed(Input.GetAxis("Horizontal"));

        if (Input.GetButton("Jump") && Jump != null)
        {
            Jump();
        }
    }
}
