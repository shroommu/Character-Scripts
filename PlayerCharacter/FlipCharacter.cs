using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
    Vector3 _rotateDirection;
    void Start()
    {
        MoveViaKeys.Direction = Flip;
    }

    void Flip(float direction)
    {
        _rotateDirection.y = direction;
        transform.rotation = Quaternion.Euler(_rotateDirection);
    }
}
