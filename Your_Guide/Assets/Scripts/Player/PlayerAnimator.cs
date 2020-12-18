using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]private Animator playerAnimator;

    [Header("Attaque Parameter")]
    public string attTrigger;
    public string attResetTrigger;

    [Header("Player Statue Parameter")]
    public string stunParameter;

    [Header("Switch Parameter")]
    public string switchParameter;

    public void TriggerSwitchParameter()
    {
        playerAnimator.SetTrigger(switchParameter);
    }

    public void TriggerAttparameter()
    {
        playerAnimator.SetTrigger(attTrigger);
    }
}
