using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGestion : MonoBehaviour
{

    [SerializeField] protected int maxLifeValue;
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

        Debug.Log(lifeValue, gameObject);

        if (lifeValue == 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {

    }

}
