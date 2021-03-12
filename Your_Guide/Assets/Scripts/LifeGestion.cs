using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGestion : MonoBehaviour
{

    [SerializeField] protected float maxLifeValue;
    [SerializeField] protected float initialLifeValue;
    [SerializeField] private bool godMode = false;
    protected float lifeValue;

    private void Awake()
    {
        lifeValue = initialLifeValue;
    }

    public void TakeDamage(int DamageValue)
    {
        lifeValue -= DamageValue;
        lifeValue = Mathf.Clamp(lifeValue, 0, maxLifeValue);

        Debug.Log(lifeValue, gameObject);

        if (lifeValue == 0 && !godMode)
        {
            Death();
        }
    }

    public virtual void Death()
    {

    }

}
