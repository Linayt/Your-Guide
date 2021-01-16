using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptacleStatue : MonoBehaviour
{
    [Header("Movement")]
    public bool isFollow;
    public bool isSprint;
    public bool isStun;

    [Header("Battle")]
    public bool isScared;
    //[SerializeField] private float minDistanceToBeScared;

    private void Awake()
    {
        isFollow = false;
        isStun = false;
        isScared = false;
    }


}
