using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    enum DamageType { Player,Enemi}
    [SerializeField] private DamageType attackType = DamageType.Player;

    private EnemiControler eControler;
    private ReceptacleControler rControler;
    private PlayerControler pControler;

    private void Awake()
    {
        switch (attackType)
        {
            case DamageType.Player:
                pControler = FindObjectOfType<PlayerControler>();

                break;
            case DamageType.Enemi:
                eControler = FindObjectOfType<EnemiControler>();

                break;

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (attackType != DamageType.Player)
        {
            eControler = null;

        }

        rControler = null;
        
        switch (attackType)
        {
            case DamageType.Player:
                eControler = other.transform.GetComponent<EnemiControler>();

                if (eControler != null)
                {
                    int degat = pControler.pAttaque.degatValue;
                    eControler.eLife.TakeDamage(degat);
                }

                break;
            case DamageType.Enemi:
                rControler = other.transform.GetComponent<ReceptacleControler>();

                if (rControler != null)
                {
                    int degat = eControler.eAttack.degatValue;
                    rControler.rLife.TakeDamage(degat);
                }

                break;

        }
    }

}
