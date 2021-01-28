using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAttack : MonoBehaviour
{
    private EnemiControler eControler;

    public int degatValue = 1;

    public float forceDegatPlayer = 500;
    public float upwardForceModifier = 1;

    


    private void Awake()
    {
        eControler = transform.GetComponent<EnemiControler>();
    }


}
