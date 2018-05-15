using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    private float velocity;//the current velocity of the enemy in x
    public float health = 1;//the enemy health
    public float healthReturn = 1;//the value that the enemy should return to if upon respawning
    public GameObject myTarget; // the location of the player the enemies case
    public GameObject art;//game art that be deactivated when the it "explodes"
    public GameObject explosion;//the FX for enemyExploding
    public Animator EnemyAnims;//drop an Animator component here
    public UnityEngine.AI.NavMeshAgent navMeshAgent; //accesses the navmesh component of an enemy
    public List<WeaponClass> killerWeaponsList;//this is a list of weapons used to kill the enemies 


    void Awake()
    {
        navMeshAgent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();//finds the required NavMeshAgent
        this.gameObject.SetActive(true);//turns off the gameObject
        Invoke("Deactivate", 1.5f);
        killerWeaponsList = new List<WeaponClass>();//news up the killerWeaponsList instance 
        EnemyAnims.SetFloat("Swim", 0);
    }

    void OnEnable()
    {
        myTarget = navMeshAgent.gameObject;//Sets the target to itself
        healthReturn = health;//sets the return health to the users current health value
        EnemySpawnerDelegate.ActivateEnemyEvent -= Reactivate;//unsubscripts the Reactivate function the the EnemySpawnerDelegate event
    }

    public void StartEnemyMove()
    {
        StartCoroutine(MoveEnemyToTarget());//replaced the Update call and only runs when called
    }

    IEnumerator MoveEnemyToTarget()//sets the destination of the NavMeshAgent to the player
    {
        navMeshAgent.destination = myTarget.transform.position;
        velocity = navMeshAgent.velocity.x;
        EnemyAnims.SetFloat("Swim", velocity);
        yield return null;
    }
    void Deactivate()
    {
        EnemyAnims.SetBool("Explode", false);
        this.gameObject.SetActive(false);
        EnemyAnims.SetLayerWeight(2, 0f);
    }

    IEnumerator PlayDamageAnim()
    {
        var i = Random.Range(0.5f, 1);
        EnemyAnims.SetLayerWeight(2, i);
        EnemyAnims.SetBool("Damage", true);
        yield return new WaitForSeconds(0.2f);
        EnemyAnims.SetLayerWeight(2, 0);
        EnemyAnims.SetBool("Damage", false);
    }

    public void LowerHealth(Collider _c)
    {
        StartCoroutine(PlayDamageAnim());

    
        if (health <= 0)
        {
            art.SetActive(false);
            explosion.SetActive(true);
            Invoke("Deactivate", 1.5f);
        }
    }

    void Reactivate(Vector3 _v)

    {
        EnemyAnims.SetLayerWeight(2, 0);

        health = healthReturn;
        this.transform.position = _v;
        art.SetActive(true);
        explosion.SetActive(false);
        this.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider _c)
    {
        LowerHealth(_c);
    }
    void OnDisable()
    {
        EnemySpawnerDelegate.ActivateEnemyEvent += Reactivate;//subscripts the Reactivate function the the EnemySpawnerDelegate event
    }
}

public class WeaponClass
{
}
