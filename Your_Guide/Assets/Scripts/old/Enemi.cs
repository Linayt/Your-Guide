using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemi : MonoBehaviour
{
    [SerializeField] Animator animatorEnnemi;
    [SerializeField] float minDistanceToFollow;
    [SerializeField] float minDistanceToUnfollow;
    Transform targetTransform;
    public string followParameterName;
    public string unfollowParameterName;
    private NavMeshAgent agent;
    private NavMeshPath path;
    private int index;
    private Vector3 currentCiblePos;
    private Rigidbody rigid;
    [SerializeField] private float pathMinDistance;
    [SerializeField] private float minDistanceToAttack;
    public string attaqueParameterName;
    [SerializeField] private float vitesse;


    [SerializeField] private float minDistanceToGrab;
    [SerializeField] private Transform anchorGrab;
    public string runawayParameterName;

    public Transform[] listOfPositionToRunAway;
    private Transform posToRunAway;

    bool asGrabed;
    //[SerializeField] private float minTimeToRecalculatePath;
    //float timer;
    bool shouldMove;

    // Start is called before the first frame update
    void Awake()
    {
        targetTransform = FindObjectOfType<Target>().transform;
        path = new NavMeshPath();
        rigid = transform.GetComponent<Rigidbody>();
        agent = transform.GetComponent<NavMeshAgent>();
        asGrabed = false;
        //timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsTargetInRange()
    {
        float distance = Vector3.Distance(targetTransform.position, transform.position);
        bool inRange = distance < minDistanceToFollow;
        return inRange;
    }

    public bool IsUnfollow()
    {
        float distance = Vector3.Distance(targetTransform.position, transform.position);
        bool inRange = distance < minDistanceToUnfollow;
        return inRange;
    }

    

    public void Idle()
    {

    }

    public void Follow()
    {
        CheckTargetReach(targetTransform);
        MoveToCible();
    }

    public void InitializePath()
    {
        CalculatePath(targetTransform);
    }

    public void Grab()
    {
        float distance = Vector3.Distance(targetTransform.position, transform.position);
        bool isInRange = distance <= minDistanceToGrab;

        if (isInRange && !asGrabed)
        {
            asGrabed = true;
            targetTransform.parent = anchorGrab;
            targetTransform.localPosition = Vector3.zero;
            animatorEnnemi.SetTrigger(runawayParameterName);
        }
        else if(isInRange==false)
        {
            animatorEnnemi.SetTrigger(followParameterName);
        }
    }


    public void RunAway()
    {
        CheckTargetReach(posToRunAway);
        MoveToCible();
    }

    public void ChoosePosToRunAway()
    {
        int indexrandom = Random.Range(0, listOfPositionToRunAway.Length - 1);
        posToRunAway = listOfPositionToRunAway[indexrandom];
        CalculatePath(posToRunAway);
    }

    public void CalculatePath(Transform target)
    {
        if (agent.CalculatePath(target.position, path))
        {
            index = 0;
            currentCiblePos = path.corners[0];
            Debug.Log("new path");
            shouldMove = true;
        }
    }

    public void CheckTargetReach(Transform target)
    {
        float distanceToTarget = Vector3.Distance(currentCiblePos, rigid.transform.position);
        if (distanceToTarget <= pathMinDistance)
        {
            if (index < path.corners.Length - 1)
            {
                index++;
                Debug.Log(index);
                rigid.velocity = Vector3.zero;
                currentCiblePos = path.corners[index];
            }
            else
            {
                rigid.velocity = Vector3.zero;
                shouldMove = false;
                float distanceToAttack = Vector3.Distance(transform.position, target.position);
                if (distanceToAttack <= minDistanceToAttack)
                {
                    Debug.Log("att");
                    animatorEnnemi.SetTrigger(attaqueParameterName);
                }
                else
                {
                    CalculatePath(target);
                }

            }
        }
    }

    public void MoveToCible()
    {
        Vector3 toCiblePos = (currentCiblePos - rigid.transform.position).normalized;
        if (shouldMove)
        {
            rigid.velocity = toCiblePos * vitesse;

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (path != null)
        {
            for (int i = 0; i < path.corners.Length; i++)
            {
                Gizmos.DrawSphere(path.corners[i], 0.5f);
            }
        }
    }
}
