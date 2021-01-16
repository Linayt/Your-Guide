using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiStatue : MonoBehaviour
{
    private EnemiControler eControler;

    public bool follow;
    public bool stun;

    public bool death;

    private void Awake()
    {
        eControler = transform.GetComponent<EnemiControler>();
        death = false;
    }


}
