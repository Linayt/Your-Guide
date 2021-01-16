using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGestion : MonoBehaviour
{

    [SerializeField] int maxLifeValue;
    [SerializeField] protected int initialLifeValue;

    protected int lifeValue;

    private void Awake()
    {
        lifeValue = initialLifeValue;
    }

    public void TakeDamage(int DamageValue)
    {
        lifeValue -= DamageValue;
        lifeValue = Mathf.Clamp(lifeValue, 0, maxLifeValue);

        if (lifeValue == 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {

    }

}
