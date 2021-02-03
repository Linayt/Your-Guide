using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttaque : MonoBehaviour
{
    private PlayerControler pControler;

    //public int degatValue;
    public LayerMask colliderAttackLayer;

    public Transform origineAttCone;
    public Transform origineAttImpact;

    public float attKnockBackUpModifier;

    public float timeBumpEnemi;
    
    public void DegatCone(int degat, float rangeAtt, float effectiveRange, float knockBackForce)
    {
        Collider[] colliderEntities = Physics.OverlapSphere(origineAttCone.position, rangeAtt, colliderAttackLayer);
        foreach (Collider cible in colliderEntities)
        {
            Vector3 toCible = cible.transform.position - origineAttCone.position;
            Vector3 knockBackDirection = toCible.normalized * knockBackForce;
            knockBackDirection.y = attKnockBackUpModifier;

            float dotValue = Vector3.Dot(origineAttCone.forward.normalized, toCible.normalized);

            if(dotValue>= effectiveRange)
            {
                EnemiControler eControler = cible.GetComponent<EnemiControler>();
                if (eControler)
                {
                    eControler.eLife.TakeDamage(degat);
                    eControler.eStatue.Bump(knockBackDirection, timeBumpEnemi);
                }
            }
        }
    }

}
