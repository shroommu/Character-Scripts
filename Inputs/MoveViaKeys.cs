using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class MoveViaKeys : MonoBehaviour
{
    //Events
    public static UnityAction<float> Speed;

    public static UnityAction<Coroutine> Jump;
    public static UnityAction<float> Direction;

    //Properties
    private CharacterController _myController;

    public Animator CharacterAnim;
    public CharacterMovement MyCharacterMovement;

    //Methods
    private void Start()
    {
       // EndGame.TurnOffGame += DisableScript;
        MyCharacterMovement.MyCharacterController = GetComponent<CharacterController>();
    }

    private void DisableScript()
    {
        this.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Direction != null)
        {
            Direction(180);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Direction != null)
        {
            Direction(0);
        }

        MyCharacterMovement.Move(Input.GetAxis("Horizontal"));
        
        if (Input.GetButton("Jump"))
        {
           
           // MyCharacterMovement
            //Jump(Invoke());
            StartCoroutine(MyCharacterMovement.Jump());
        }
    }
}