using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiLife : LifeGestion
{
    private EnemiControler eControler;

    

    private void Awake()
    {
        lifeValue = initialLifeValue;
        eControler = transform.GetComponent<EnemiControler>();
    }

    public override void Death()
    {
        eControler.eStatue.death = true;
        eControler.eAnimator.enemiAnimator.SetBool(eControler.eAnimator.deathParameterName, true);
    }
}
