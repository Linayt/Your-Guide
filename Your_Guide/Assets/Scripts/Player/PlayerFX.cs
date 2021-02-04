using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerFX : MonoBehaviour
{
    PlayerControler pControler;
    public enum typeOfAttack { Attack1,Attack2,Attack3}
    public string attackEventName;
    public string degatEventName;

    public string positionDegatParameterName;

    public VisualEffect Attack1;
    public VisualEffect Attack2;
    public VisualEffect Attack3;

    private void Awake()
    {
        pControler = transform.GetComponent<PlayerControler>();

    }

    public void startFXAttack(typeOfAttack type)
    {
        switch(type)
        {
            case typeOfAttack.Attack1:

                Attack1.SendEvent(attackEventName);
            
                break;

            case typeOfAttack.Attack2:

                Attack2.SendEvent(attackEventName);

                break;

            case typeOfAttack.Attack3:

                Attack3.SendEvent(attackEventName);

                break;


        }
    }

    public IEnumerator StartFXAttackTiming(typeOfAttack type,float effectiveTime)
    {
        yield return new WaitForSeconds(effectiveTime);
        startFXAttack(type);
    }

    public void startCoroutineFX(typeOfAttack type, float effectiveTime)
    {
        StartCoroutine(StartFXAttackTiming(type, effectiveTime));
    }

    public void startFXDegat(typeOfAttack type, Vector3 position)
    {
        switch (type)
        {
            case typeOfAttack.Attack1:
                Attack1.SetVector3(positionDegatParameterName, position);
                Attack1.SendEvent(degatEventName);

                break;

            case typeOfAttack.Attack2:
                Attack2.SetVector3(positionDegatParameterName, position);
                Attack2.SendEvent(degatEventName);

                break;
        }
    }
}
