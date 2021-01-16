using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiProjectile : MonoBehaviour
{
    [HideInInspector] public int degatValue;
    public Rigidbody rigid;

    private void OnCollisionEnter(Collision collision)
    {
        ReceptacleControler rControler = collision.transform.GetComponent<ReceptacleControler>();
        if (rControler != null)
        {
            rControler.rLife.TakeDamage(degatValue);
        }

        Destroy(gameObject);
    }
}
