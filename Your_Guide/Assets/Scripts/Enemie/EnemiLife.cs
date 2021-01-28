using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiLife : LifeGestion
{
    private EnemiControler eControler;
    [SerializeField] private Image lifeFillImage;
    

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

    public void SetLifeBareValue()
    {
        if (lifeFillImage != null)
        {
            float fillValue = lifeValue / initialLifeValue;
            lifeFillImage.fillAmount = fillValue;

        }
    }

}
