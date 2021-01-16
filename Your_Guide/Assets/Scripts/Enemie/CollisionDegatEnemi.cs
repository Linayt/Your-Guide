using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDegatEnemi : MonoBehaviour
{
    [SerializeField]private EnemiControler eControler;

    private ReceptacleControler rControler;

    private PlayerControler pControler;

   


    private void OnTriggerEnter(Collider other)
    {
        rControler = other.transform.GetComponent<ReceptacleControler>();
        if (rControler != null)
        {
            int degat = eControler.eAttack.degatValue;
            rControler.rLife.TakeDamage(degat);
            
        }
        else
        {
            pControler = other.transform.GetComponent<PlayerControler>();
            if (pControler != null)
            {
                float force = eControler.eAttack.forceDegatPlayer;
                float upward = eControler.eAttack.upwardForceModifier;
                Rigidbody rigidPlayer = pControler.GetComponent<Rigidbody>();

                rigidPlayer.AddExplosionForce(force, transform.position, 10, upward);

            }
        }

        rControler = null;
        pControler = null;


    }
}
