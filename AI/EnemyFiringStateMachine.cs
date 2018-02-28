using UnityEngine;
using System.Collections;

public class EnemyFiringStateMachine : MonoBehaviour
{

    //added to the enemy forward trigger
    public Animator enemyAnim;

    void EndFiring()
    {
        enemyAnim.SetBool("Armed", false);
        enemyAnim.SetBool("Fire", false);
    }

    void Awake()
    {
        EndFiring();
        //EndGame.TurnOffGame += EndFiring;
    }

    void OnTriggerEnter()
    {
        enemyAnim.SetBool("Armed", true); //Custom function changes the animators state
        enemyAnim.SetBool("Fire", true);
    }

    void OnTriggerExit(Collider _c)
    {
        EndFiring();
    }
}
