using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAttaque))]
[RequireComponent(typeof(PlayerSwitch))]
[RequireComponent(typeof(PlayerAdrenaline))]
[RequireComponent(typeof(PlayerStatue))]
[RequireComponent(typeof(PlayerFX))]


[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(Animator))]


public class PlayerControler : MonoBehaviour
{

    [HideInInspector] public PlayerAttaque pAttaque;
    [HideInInspector] public PlayerMovement pMovement;
    [HideInInspector] public PlayerInput pInput;
    [HideInInspector] public PlayerAnimator pAnimator;
    [HideInInspector] public PlayerSwitch pSwitch;
    [HideInInspector] public PlayerAdrenaline pAdrenaline;
    [HideInInspector] public PlayerStatue pStatue;
    [HideInInspector] public PlayerFX pFX;


    [HideInInspector] public Rigidbody rigid;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = transform.GetComponent<Rigidbody>();
        pInput = transform.GetComponent<PlayerInput>();
        pMovement = transform.GetComponent<PlayerMovement>();
        pAttaque = transform.GetComponent<PlayerAttaque>();
        pAnimator = transform.GetComponent<PlayerAnimator>();
        pSwitch = transform.GetComponent<PlayerSwitch>();
        pAdrenaline = transform.GetComponent<PlayerAdrenaline>();
        pStatue = transform.GetComponent<PlayerStatue>();
        pFX = transform.GetComponent<PlayerFX>();
    }

    // Update is called once per frame
    void Update()
    {
        pAdrenaline.SetJaugeFillValue();
    }

    private void FixedUpdate()
    {
        pMovement.Move(pInput.GetDirectionInput(), rigid);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(0, 1, 0), 1);
    }*/
}
