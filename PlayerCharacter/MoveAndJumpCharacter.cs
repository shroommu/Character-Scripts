using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MoveAndJumpAndFloatCharacter : CharacterMovement
{
    //Properties
    public float Speed = 1;

    public float JumpForce = 75;
    private float _jumpReturn;
    public float Gravity = 1;
    private Vector3 _moveDirection;

    private void Start()
    {
        UiAnimStates.CanPlay += CanPlayHandler;
        CanPlayHandler();
        EndGame.TurnOffGame += EndGameHandler;
    }


    private void EndGameHandler()
    {
        //MoveViaKeys.Speed -= MoveCharacter;
        //MoveViaKeys.Jump -= JumpAndFloatCharacter;
    }

    private void CanPlayHandler()
    {
        
        _jumpReturn = JumpForce;
        //MoveCharacterViaButtons.MoveCharacter += MoveCharacter;
        //MoveViaKeys.Speed += MoveCharacter;
       // MoveViaKeys.Jump += JumpAndFloatCharacter;
        //StartCoroutine(StopJumpForce());
    }

    public override IEnumerator Jump ()
    {
        while (JumpForce > 0)
        {
            JumpForce--;
            yield return new WaitForFixedUpdate();
        }
        JumpForce = _jumpReturn;
    }

    public void JumpAndFloatCharacter()
    {
        JumpForce = _jumpReturn;
        //StartCoroutine(StopJumpForce());
    }

    private CharacterController _characterController;

    public override CharacterController MyCharacterController
    {
      
        set
        {
            _characterController = value;
        }
    }

    public override Animator MyAnimator
    {
        set { throw new NotImplementedException(); }
    }

    public override void LeftHander()
    {
        throw new NotImplementedException();
    }

    public override void RightHander()
    {
        throw new NotImplementedException();
    }

    public override void UpHander()
    {
        throw new NotImplementedException();
    }

    public override void DownHander()
    {
        throw new NotImplementedException();
    }

    public override void SpaceHander()
    {
        throw new NotImplementedException();
    }

    public override void Move(float speed)
    {
        if (_characterController.isGrounded)
        {
            _moveDirection.x = speed * Speed;
            _moveDirection.z = 0;
            _moveDirection.y = JumpForce * Time.deltaTime;
        }
        _moveDirection.y -= Gravity * Time.deltaTime;
        _characterController.Move(_moveDirection * Time.deltaTime);
    }
}