using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiMovement : AiMovementWithVelocity
{
    [SerializeField] private float vitesse;

    [Header("Distance")]
    [SerializeField] private float minDistanceToFollowReceptacle;
    [SerializeField] private float minDistanceToFollowPlayer;


    private ReceptacleControler rControler;
    private PlayerControler pControler;



    private Transform currentTarget;

    private void Awake()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        agent.enabled = false;
        rigid = transform.GetComponent<Rigidbody>();
        path = new NavMeshPath();
        rControler = FindObjectOfType<ReceptacleControler>();
        pControler = FindObjectOfType<PlayerControler>();
    }

    public bool IsInRangeToFollowReceptacle()
    {
        float distance = Vector3.Distance(rControler.transform.position, transform.position);
        bool inRange = distance <= minDistanceToFollowReceptacle;
        return inRange;
    }

    public bool IsInRangeToFollowPlayer()
    {
        float distance = Vector3.Distance(pControler.transform.position, transform.position);
        bool inRange = distance <= minDistanceToFollowPlayer;
        return inRange;
    }

    public void ChooseTarget()
    {
        if (IsInRangeToFollowReceptacle())
        {
            currentTarget = rControler.transform;
            return;
        }
        else if (IsInRangeToFollowPlayer())
        {
            currentTarget = pControler.transform;
            return;
        }
        else
        {
            currentTarget = null;
        }
    }

    public void InizialisePath()
    {
        if (currentTarget)
        {
            Calculatepath(currentTarget);

        }
    }

    public void Follow()
    {
        if (currentTarget)
        {
            CheckTargetReach(currentTarget);

        }
        MoveToCible(vitesse);
        if(!shouldMove && currentTarget)
        {
            InizialisePath();
        }
    }





}
