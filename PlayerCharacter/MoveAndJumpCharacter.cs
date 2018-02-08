using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MoveAndJumpAndFloatCharacter : ScriptableObject
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
        MoveViaKeys.Jump -= JumpAndFloatCharacter;
    }

    private void CanPlayHandler()
    {
        
        _jumpReturn = JumpForce;
        //MoveCharacterViaButtons.MoveCharacter += MoveCharacter;
        //MoveViaKeys.Speed += MoveCharacter;
        MoveViaKeys.Jump += JumpAndFloatCharacter;
        //StartCoroutine(StopJumpForce());
    }

    private IEnumerator StopJumpForce()
    {
        while (JumpForce > 0)
        {
            JumpForce--;
            yield return new WaitForFixedUpdate();
        }
    }

    private void JumpAndFloatCharacter()
    {
        JumpForce = _jumpReturn;
        //StartCoroutine(StopJumpForce());
    }

    public void MoveCharacter(float speed, CharacterController characterController)
    {
        if (characterController.isGrounded)
        {
            _moveDirection.x = speed * Speed;
            _moveDirection.z = 0;
            //_moveDirection.y = JumpForce * Time.deltaTime;
        }
        _moveDirection.y -= Gravity * Time.deltaTime;
        characterController.Move(_moveDirection * Time.deltaTime);
    }
}