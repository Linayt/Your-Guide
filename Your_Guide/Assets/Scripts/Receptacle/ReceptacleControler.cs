using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

[RequireComponent(typeof(ReceptacleMovement))]
[RequireComponent(typeof(ReceptacleAnimator))]
[RequireComponent(typeof(ReceptacleStatue))]



public class ReceptacleControler : MonoBehaviour
{
    [HideInInspector]
    public ReceptacleMovement rMovement;
    [HideInInspector]
    public ReceptacleAnimator rAnimator;
    [HideInInspector]
    public ReceptacleStatue rStatue;

    // Start is called before the first frame update
    void Start()
    {
        rMovement = transform.GetComponent<ReceptacleMovement>();
        rAnimator = transform.GetComponent<ReceptacleAnimator>();
        rStatue = transform.GetComponent<ReceptacleStatue>();
    }

    // Update is called once per frame
    void Update()
    {
        rAnimator.SetParameterValue();
    }
}
