using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAttack : MonoBehaviour
{
    private EnemiControler eControler;

    public int degatValue = 1;

    public float forceDegatPlayer = 500;
    public float upwardForceModifier = 1;

    public Transform origineAtt;

    public float timeBumpPlayer;

    public LayerMask colliderAttackLayer;

    private void Awake()
    {
        eControler = transform.GetComponent<EnemiControler>();
    }


    public void DegatCone(int degat, float rangeAtt, float effectiveRange, float knockBackForce)
    {
        Collider[] colliderEntities = Physics.OverlapSphere(origineAtt.position, rangeAtt, colliderAttackLayer);

        foreach (Collider cible in colliderEntities)
        {
            Vector3 toCible = cible.transform.position - origineAtt.position;
            Vector3 knockBackDirection = toCible.normalized * knockBackForce;
            knockBackDirection.y = upwardForceModifier;

            float dotValue = Vector3.Dot(origineAtt.forward.normalized, toCible.normalized);

            if (dotValue >= effectiveRange)
            {
                ReceptacleControler rControler = cible.GetComponent<ReceptacleControler>();
                if (rControler)
                {
                    rControler.rLife.TakeDamage(degat);
                    
                }
                else
                {
                    PlayerControler pControler = cible.GetComponent<PlayerControler>();
                    if (pControler != null)
                    {
                        pControler.pStatue.Bump(knockBackDirection, timeBumpPlayer);
                    }
                }
            }
        }
    }

    public void StartDamageCoroutine(AnimatorStateInfo stateInfo, float effectiveTimeBeforeDegat, bool useConeDetection, int degatValue, float attRange, float effectiveRange, float bumpForce)
    {
        StartCoroutine(InflictDamage(stateInfo, effectiveTimeBeforeDegat, useConeDetection, degatValue, attRange, effectiveRange, bumpForce));
    }

    public IEnumerator InflictDamage(AnimatorStateInfo stateInfo, float effectiveTimeBeforeDegat, bool useConeDetection, int degatValue, float attRange, float effectiveRange, float bumpForce)
    {
        while (stateInfo.normalizedTime < effectiveTimeBeforeDegat)
        {
            yield return new WaitForEndOfFrame();
        }
        DegatCone(degatValue, attRange, effectiveRange, bumpForce);
    }



}
