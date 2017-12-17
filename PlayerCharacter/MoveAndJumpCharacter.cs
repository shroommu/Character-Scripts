using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndJumpCharacter : MonoBehaviour {

	//Properties
    public float speed = 1;
    public float jumpForce = 75;
    private float jumpReturn;
    public float gravity = 1;
    private Vector3 moveDirection;
    private CharacterController myController;
    public Animator characterAnim;

    void Start()
    {
        UIAnimStates.CanPlay += CanPlayHandler;
        CanPlayHandler();
        EndGame.TurnOffGame += EndGameHandler;
    }

    private void EndGameHandler()
    {
        MoveViaKeys.Speed -= MoveCharacter;
        MoveViaKeys.Jump -= JumpCharacter;
    }

    private void CanPlayHandler ()
    {
        myController = GetComponent<CharacterController>();
        jumpReturn = jumpForce;
        MoveCharacterViaButtons.MoveCharacter += MoveCharacter;
        MoveViaKeys.Speed += MoveCharacter;
        MoveViaKeys.Jump += JumpCharacter;
        StartCoroutine(StopJumpForce());
    }

    IEnumerator StopJumpForce()
    {
        while (jumpForce > 0)
        {
            jumpForce--;
            yield return new WaitForFixedUpdate();
        }
    }

    void JumpCharacter()
    {
        jumpForce = jumpReturn;
        StartCoroutine(StopJumpForce());
    }

    void MoveCharacter(float _speed)
    {
        if (myController.isGrounded)
        {
            moveDirection.x = _speed * speed;
            moveDirection.z = 0;
            moveDirection.y = jumpForce * Time.deltaTime;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        myController.Move(moveDirection * Time.deltaTime);
    }
}
