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

    //Methods
    void Start()
    {
        EndGame.TurnOffGame += DisableScript;
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
            Speed(Input.GetAxis("Horizontal"));

        if (Input.GetButton("Jump") && Jump != null)
        {
            Jump();
        }
    }
}
