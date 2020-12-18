using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

[RequireComponent(typeof(EnemiMovement))]
[RequireComponent(typeof(EnemiStatue))]
[RequireComponent(typeof(EnemiAnimator))]



public class EnemiControler : MonoBehaviour
{
    [HideInInspector] public EnemiMovement eMovement;
    [HideInInspector] public EnemiStatue eStatue;
    [HideInInspector] public EnemiAnimator eAnimator;


    
    void Awake()
    {
        eMovement = transform.GetComponent<EnemiMovement>();
        eStatue = transform.GetComponent<EnemiStatue>();
        eAnimator = transform.GetComponent<EnemiAnimator>();
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
    }
}
