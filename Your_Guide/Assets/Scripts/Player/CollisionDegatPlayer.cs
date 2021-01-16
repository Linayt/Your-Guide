using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDegatPlayer : MonoBehaviour
{
    private PlayerControler pControler;

    private EnemiControler eControler;


    private void Awake()
    {
        pControler = FindObjectOfType<PlayerControler>();

    }

    private void OnTriggerEnter(Collider other)
    {
        eControler = other.transform.GetComponent<EnemiControler>();

        if (eControler != null)
        {
            int degat = pControler.pAttaque.degatValue;
            eControler.eLife.TakeDamage(degat);

        }

        eControler = null;


    }

}
