using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceptacleLife : LifeGestion
{
    private ReceptacleControler rControler;
    [SerializeField] private Image lifeBarFill;


    public override void Death()
    {
        Destroy(gameObject);
    }

    public void SetLifeValue()
    {
        float fillValue = lifeValue / maxLifeValue;
        lifeBarFill.fillAmount = fillValue;
    }

}
