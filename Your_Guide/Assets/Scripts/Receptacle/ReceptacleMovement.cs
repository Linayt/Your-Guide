using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReceptacleMovement : AiMovementWithVelocity
{
    [SerializeField] private float vitesseFollow;
    [SerializeField] private float vitesseSprint;

    [Header("Movement Distance")]
    [SerializeField] private float minDistanceToFollow;
    [SerializeField] private float minDistanceToSprint;
    [SerializeField] private float minDistanceToStop;
    [SerializeField] private float minDistanceToBeScared;

    private PlayerControler player;

    private void Awake()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        agent.enabled = false;
        rigid = transform.GetComponent<Rigidbody>();
        path = new NavMeshPath();

        player = FindObjectOfType<PlayerControler>();
        Calculatepath(player.transform);
    }


    public bool IsInRangeToFollow()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        bool InRange = distance >= minDistanceToFollow;
        return InRange;
    }

    public bool IsInRangeToSprint()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        bool InRange = distance >= minDistanceToSprint;
        return InRange;
    }

    public bool IsInRangeToStop()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        bool InRange = distance <= minDistanceToStop;
        return InRange;
    }

    public bool IsInrangeToBeScared()
    {
        EnemiControler[] enemiList = FindObjectsOfType<EnemiControler>();
        if (enemiList.Length != 0)
        {
            foreach (EnemiControler eControler in enemiList)
            {
                Vector3 posE = eControler.transform.position;
                float distance = Vector3.Distance(posE, transform.position);
                bool InRange = distance <= minDistanceToBeScared;
                if (InRange)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            return false;
        }
    }


    public void InizialisePath()
    {
        Calculatepath(player.transform);
    }

    public void Follow()
    {
        CheckTargetReach(player.transform);
        MoveToCible(vitesseFollow);
        if(!shouldMove && IsInRangeToFollow())
        {
            InizialisePath();
        }
    }

    public void Sprint()
    {
        CheckTargetReach(player.transform);
        MoveToCible(vitesseSprint);
        if (!shouldMove && IsInRangeToSprint())
        {
            InizialisePath();
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
