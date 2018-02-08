using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Weapons;
using System;

public class AnimateCharacter : MonoBehaviour
{
    //Events
    //public static UnityAction<WeaponType.weaponSelection> ReturnFire;
    //public static UnityAction<WeaponType.weaponSelection> EndReturnFire;
    //Properties
    public Animator CharacterAnim;
    public Weapon Weapon;
    public GameObject OnFx;
    public AudioSource SoundFx;
    public WeaponsList MyWeaponsList;

    public void Step () {
        SoundFx.Play();
    }
   
    void Start()
    {
        Jump();
        EndGame.EndGameBoolHandler += OnEndGameEvent;
        MoveViaKeys.Jump += Jump;
        MoveViaKeys.Speed += Walk;
        WeaponButton.CanFire += FireHandler;
    }

    private void FireHandler(float num)
    {
        CharacterAnim.SetLayerWeight(1, 1);
        CharacterAnim.SetTrigger("FireWeapon");
    }
     public void FireWeapon (                                                                                                                                                                                                                                                               ) {
         MyWeaponsList.CurrentWeapon.Fire(true);
       // Invoke("EndFireWeapon", _data.CurrentWeapon.FireRate);
     }

     public void EndFireWeapon () {
       // Data.CurrentWeapon.Fire(false);
     }

    void OnWinGame()
    {
        // StartCoroutine(RunCoroutine(0.1f, "Win"));
    }

    void OnLooseGame()
    {
        Walk(0);
        CharacterAnim.SetBool("Arm", false);
        CharacterAnim.SetLayerWeight(1, 0);
        CharacterAnim.SetBool("Die", true);
        EndGame.EndGameBoolHandler -= OnEndGameEvent;
        this.enabled = false;
    }

    bool OnEndGameEvent(bool b)
    {
        if (b)
        {
            OnWinGame();
        }
        else
        {
            OnLooseGame();
        }
        return b;
    }

    void Walk(float speed)
    {
        CharacterAnim.SetFloat("Walk", speed);
    }
    void Jump()
    {
        CharacterAnim.SetBool("Jump", true);
    }

    void OnTriggerEnter(Collider other)
    {
        CharacterAnim.SetBool("Jump", false);
    }
}