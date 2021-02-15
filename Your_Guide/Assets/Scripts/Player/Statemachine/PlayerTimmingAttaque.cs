using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimmingAttaque : StateMachineBehaviour
{
    private PlayerControler pControler;

    [Header("Combo")]
    [SerializeField] bool canCombo;
    [SerializeField] float minNormalizedTimeToCombo;
    [SerializeField] float maxNormalizedTimeToCombo;

    [Header("Reset")]
    [SerializeField] bool canReset;
    [SerializeField] float timeToResetCombo;

    float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //pControler = animator.GetComponent<PlayerControler>();
        pControler = FindObjectOfType<PlayerControler>();

        timer = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (canCombo)
        {
            //Debug.Log("Can Combo");
            //getIsOnTime(stateInfo);
            //Debug.Log(getIsOnTime(stateInfo));
            if (Input.GetButtonDown(pControler.pInput.attInput) && getIsOnTime(stateInfo))
            {
                Debug.Log("attack");
                animator.SetTrigger(pControler.pAnimator.attTrigger);
            }

        }
        if (canReset)
        {
            timer += Time.deltaTime;
            if (timer >= timeToResetCombo)
            {
                animator.SetTrigger(pControler.pAnimator.attResetTrigger);
            }
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


    bool getIsOnTime(AnimatorStateInfo stateInfo)
    {
        
        float currentAnimeTime = stateInfo.normalizedTime;
        currentAnimeTime = currentAnimeTime % 1;
        //Debug.Log(currentAnimeTime);
        bool isOnTime = currentAnimeTime >= minNormalizedTimeToCombo && currentAnimeTime <= maxNormalizedTimeToCombo;
        return isOnTime;
    }
}
