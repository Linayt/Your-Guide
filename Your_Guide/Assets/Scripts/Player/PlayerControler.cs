using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAttaque))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]


public class PlayerControler : MonoBehaviour
{

    private PlayerMovement pMovement;
    private PlayerAttaque pAttaque;
    [HideInInspector] public PlayerInput pInput;
    [HideInInspector] public PlayerAnimator pAnimator;


    private Rigidbody rigid;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = transform.GetComponent<Rigidbody>();
        pInput = transform.GetComponent<PlayerInput>();
        pMovement = transform.GetComponent<PlayerMovement>();
        pAttaque = transform.GetComponent<PlayerAttaque>();
        pAnimator = transform.GetComponent<PlayerAnimator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        pMovement.Move(pInput.GetDirectionInput(), rigid);
    }


}
