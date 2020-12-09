using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaquePlayer : MonoBehaviour
{
    public Animator playerAnimator;
    public string attTriggerAnimatorName;
    public string resetAttTriggerAnimatorName;
    public string attInput;
    public float cooldownAtt;
    public float miniTimeToResetAtt;
    public int nbMaxAtt;
    int nbAtt;
    float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = miniTimeToResetAtt;
        nbAtt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        cooldown = Mathf.Clamp(cooldown, 0, miniTimeToResetAtt);

        if (Input.GetButtonDown(attInput) && cooldown>=cooldownAtt && nbAtt<nbMaxAtt)
        {
            cooldown = 0;
            playerAnimator.SetTrigger(attTriggerAnimatorName);
            nbAtt += 1;
        }
        if (cooldown >= miniTimeToResetAtt && nbAtt>0)
        {
            playerAnimator.SetTrigger(resetAttTriggerAnimatorName);
            nbAtt = 0;            
        }
    }
}
