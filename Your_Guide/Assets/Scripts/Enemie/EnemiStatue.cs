using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiStatue : MonoBehaviour
{
    private EnemiControler eControler;

    public bool follow;
    public bool stun;
    public bool bump;

    public bool death;

    private void Awake()
    {
        eControler = transform.GetComponent<EnemiControler>();
        death = false;
        stun = false;
        bump = false;
    }

    public void Stun(float timeStun)
    {
        if (!stun && !bump)
        {
            StartCoroutine(SetStun(timeStun));
        }
    }

    public IEnumerator SetStun(float timeStun)
    {
        stun = true;
        yield return new WaitForSeconds(timeStun);
        stun = false;
    }

    public void Bump(Vector3 bumpForce, float timeBump)
    {
        if (!stun && !bump)
        {
            StartCoroutine(SetBump(bumpForce, timeBump));
        }
    }

    public IEnumerator SetBump(Vector3 bumpForce, float timeBump)
    {
        bump = true;
        eControler.rigid.AddForce(bumpForce);
        yield return new WaitForSeconds(timeBump);
        bump = false;
    }

}
