using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAnimator : MonoBehaviour
{
    private EnemiControler eControler;
    public Animator enemiAnimator;

    public string followParameterName = "Follow";
    public string stunParameterName = "Stun";
    public string attParameterName = "att";
    public string deathParameterName = "Death";

    private void Awake()
    {
        if (enemiAnimator == null)
        {
            enemiAnimator = transform.GetComponent<Animator>();

        }
        eControler = transform.GetComponent<EnemiControler>();
    }

    public void SetParametreValue()
    {
        bool follow = eControler.eMovement.IsInRangeToFollowPlayer() || eControler.eMovement.IsInRangeToFollowReceptacle();
        eControler.eStatue.follow = follow;
        enemiAnimator.SetBool(followParameterName, follow);

        bool attack = eControler.eMovement.IsInRangeToAttackTarget();
        enemiAnimator.SetBool(attParameterName, attack);

    }





}
