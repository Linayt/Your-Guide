﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

[RequireComponent(typeof(EnemiMovement))]
[RequireComponent(typeof(EnemiStatue))]
[RequireComponent(typeof(EnemiAnimator))]
[RequireComponent(typeof(EnemiLife))]
[RequireComponent(typeof(EnemiAttack))]





public class EnemiControler : MonoBehaviour
{
    [HideInInspector] public EnemiMovement eMovement;
    [HideInInspector] public EnemiStatue eStatue;
    [HideInInspector] public EnemiAnimator eAnimator;
    [HideInInspector] public EnemiLife eLife;
    [HideInInspector] public EnemiAttack eAttack;

    
    void Awake()
    {
        eMovement = transform.GetComponent<EnemiMovement>();
        eStatue = transform.GetComponent<EnemiStatue>();
        eAnimator = transform.GetComponent<EnemiAnimator>();
        eLife = transform.GetComponent<EnemiLife>();
        eAttack = transform.GetComponent<EnemiAttack>();

    }


    // Update is called once per frame
    void Update()
    {
        bool canSearchForTarget = eMovement.IsInRangeToFollowPlayer() || eMovement.IsInRangeToFollowReceptacle();

        if (canSearchForTarget)
        {
            eMovement.ChooseTarget();
        }

        eAnimator.SetParametreValue();

        eLife.SetLifeBareValue();
    }
}
