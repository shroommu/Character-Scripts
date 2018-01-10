using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndJumpAndFloatCharacter : MonoBehaviour
{
    //Properties
    public float Speed = 1;

    public float JumpForce = 75;
    private float _jumpReturn;
    public float Gravity = 1;
    private Vector3 _moveDirection;
    private CharacterController _myController;
    public Animator CharacterAnim;

    private void Start()
    {
        UIAnimStates.CanPlay += CanPlayHandler;
        CanPlayHandler();
        EndGame.TurnOffGame += EndGameHandler;
    }

    private void EndGameHandler()
    {
        MoveViaKeys.Speed -= MoveCharacter;
        MoveViaKeys.Jump -= JumpAndFloatCharacter;
    }

    private void CanPlayHandler()
    {
        _myController = GetComponent<CharacterController>();
        _jumpReturn = JumpForce;
        MoveCharacterViaButtons.MoveCharacter += MoveCharacter;
        MoveViaKeys.Speed += MoveCharacter;
        MoveViaKeys.Jump += JumpAndFloatCharacter;
        StartCoroutine(StopJumpForce());
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
        StartCoroutine(StopJumpForce());
    }

    private void MoveCharacter(float speed)
    {
        if (_myController.isGrounded)
        {
            _moveDirection.x = speed * Speed;
            _moveDirection.z = 0;
            _moveDirection.y = JumpForce * Time.deltaTime;
        }
        _moveDirection.y -= Gravity * Time.deltaTime;
        _myController.Move(_moveDirection * Time.deltaTime);
    }
}