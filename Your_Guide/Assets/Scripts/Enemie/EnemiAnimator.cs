using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAnimator : MonoBehaviour
{
    private EnemiControler eControler;
    [HideInInspector] public Animator enemiAnimator;

    public string followParameterName = "Follow";
    public string stunParameterName = "Stun";
    public string attParameterName = "att";
    public string deathParameterName = "Death";

    private void Awake()
    {
        enemiAnimator = transform.GetComponent<Animator>();
        eControler = transform.GetComponent<EnemiControler>();
    }

    public void SetParametreValue()
    {
        bool follow = eControler.eMovement.IsInRangeToFollowPlayer() || eControler.eMovement.IsInRangeToFollowReceptacle();
        eControler.eStatue.follow = follow;
        enemiAnimator.SetBool(followParameterName, follow);

    }





}
