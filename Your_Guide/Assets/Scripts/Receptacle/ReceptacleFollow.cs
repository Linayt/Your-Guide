using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptacleFollow : StateMachineBehaviour
{
    private ReceptacleControler rControler;

    private bool alreadyScared;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rControler = animator.GetComponentInParent<ReceptacleControler>();
        rControler.rMovement.InizialisePath();
        alreadyScared = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bool canFollow = rControler.rMovement.IsInRangeToFollow();
        bool canSprint = rControler.rMovement.IsInRangeToSprint();
        bool canStop = rControler.rMovement.IsInRangeToStop();
        bool isScared = rControler.rMovement.IsInrangeToBeScared();

        if (canFollow && !canStop && !isScared)
        {
            if (canSprint)
            {
                animator.SetFloat(rControler.rAnimator.vitesseParameterName, 1f);
                float vitesse = rControler.rMovement.vitesseSprint;
                rControler.rMovement.Follow(vitesse);
            }
            else
            {
                animator.SetFloat(rControler.rAnimator.vitesseParameterName, 0.5f);
                float vitesse = rControler.rMovement.vitesseFollow;
                rControler.rMovement.Follow(vitesse);

            }
        }

        if (canStop)
        {
            animator.SetFloat(rControler.rAnimator.vitesseParameterName, 0f);
        }

        if (isScared&& !alreadyScared)
        {
            alreadyScared = true;
            animator.SetBool(rControler.rAnimator.scaredParameterName, true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{        
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
