using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControler pControler;

    [Header("Movement value")]
    [SerializeField] float speed;
    [SerializeField] float turnSmoothTime = 0.1f;

    [Header("Movement reference")]
    [SerializeField] Transform axeRota;
    [SerializeField] Transform cam;


    float turnSmoothVelocity;



    private void Awake()
    {
        pControler = transform.GetComponent<PlayerControler>();
    }

    public void Move(Vector3 directionMove, Rigidbody rigid)
    {
        if (directionMove.magnitude > 0.1f && pControler.pStatue.canMove)
        {
            float targetAngle = Mathf.Atan2(directionMove.x, directionMove.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(axeRota.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            axeRota.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirec = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDirec.y = rigid.velocity.y;
            rigid.velocity = moveDirec * speed;
        }
    }

}
