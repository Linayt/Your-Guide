using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerAttaque : MonoBehaviour
{
    private PlayerControler pControler;

    //public int degatValue;
    public LayerMask colliderAttackLayer;

    public Transform origineAttCone;
    public Transform origineAttImpact;

    public float attKnockBackUpModifier;

    public float timeBumpEnemi;

    [SerializeField] private float adrenalineGain;

    /*[Header("VFX")]

    public VisualEffect Attack1VFX;
    public VisualEffect Attack2VFX;
    public VisualEffect Attack3VFX;

    public string startEvent;
    public string degatEvent;

    public string degatPositionNameParameter;*/

    public void DegatCone(int degat, float rangeAtt, float effectiveRange, float knockBackForce, PlayerFX.typeOfAttack type)
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
                    //pControler.pFX.startFXDegat(type,cible.transform.position);
                    eControler.eStatue.Bump(knockBackDirection, timeBumpEnemi);
                    pControler.pAdrenaline.AddAdrenalineValue(adrenalineGain);
                }
                else
                {
                    EnemiProjectile eProjectile = cible.GetComponent<EnemiProjectile>();
                    if (eProjectile != null)
                    {
                        //pControler.pFX.startFXDegat(type, cible.transform.position);
                        eProjectile.BumpRicochet(knockBackForce);
                        pControler.pAdrenaline.AddAdrenalineValue(adrenalineGain);
                    }
                }
            }
        }
    }


    public void DegatSphere(int degat, float rangeAtt, float knockBackForce, PlayerFX.typeOfAttack type)
    {
        Collider[] colliderEntities = Physics.OverlapSphere(origineAttCone.position, rangeAtt, colliderAttackLayer);

        foreach (Collider cible in colliderEntities)
        {
            Vector3 toCible = cible.transform.position - origineAttCone.position;
            Vector3 knockBackDirection = toCible.normalized * knockBackForce;
            knockBackDirection.y = attKnockBackUpModifier;

            EnemiControler eControler = cible.GetComponent<EnemiControler>();
            if (eControler)
            {
                eControler.eLife.TakeDamage(degat);
                pControler.pFX.startFXDegat(type, cible.transform.position);
                eControler.eStatue.Bump(knockBackDirection, timeBumpEnemi);
            }
            else
            {
                EnemiProjectile eProjectile = cible.GetComponent<EnemiProjectile>();
                if (eProjectile != null)
                {
                    pControler.pFX.startFXDegat(type, cible.transform.position);
                    eProjectile.BumpRicochet(knockBackForce);
                }
            }
        }
    }


    public void StartDamageCoroutine( float effectiveTimeBeforeDegat, bool useConeDetection, int degatValue, float attRange, float effectiveRange, float bumpForce, PlayerFX.typeOfAttack type)
    {
        StartCoroutine(InflictDamage( effectiveTimeBeforeDegat, useConeDetection, degatValue, attRange, effectiveRange, bumpForce,type));
    }

    public IEnumerator InflictDamage( float effectiveTimeBeforeDegat, bool useConeDetection, int degatValue, float attRange, float effectiveRange, float bumpForce, PlayerFX.typeOfAttack type)
    {
        yield return new WaitForSeconds(effectiveTimeBeforeDegat);
        if (useConeDetection)
        {
            DegatCone(degatValue, attRange, effectiveRange, bumpForce,type);

        }
        else
        {
            DegatSphere(degatValue, attRange, bumpForce,type);
        }
    }

}
