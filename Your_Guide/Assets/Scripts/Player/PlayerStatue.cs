using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatue : MonoBehaviour
{
    private PlayerControler pControler;

    [HideInInspector]
    public bool canMove;
    [HideInInspector]
    public bool onSwitch;

    private void Awake()
    {
        pControler = transform.GetComponent<PlayerControler>();
    }


}
