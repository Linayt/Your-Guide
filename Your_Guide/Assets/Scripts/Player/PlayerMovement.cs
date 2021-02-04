using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControler pControler;

    [Header("Movement value")]
    [SerializeField] float speed = 10;
    [Range(0,1)]
    [SerializeField] float minValueToMove = 0.1f;
    [SerializeField] float turnSmoothTime = 0.1f;

    [Header("Movement reference")]
    [SerializeField] Transform axeRota;
    [SerializeField] Transform cam;


    float turnSmoothVelocity;

    Vector3 lastDirection;

    private void Awake()
    {
        pControler = transform.GetComponent<PlayerControler>();
    }

    public void Move(Vector3 directionMove, Rigidbody rigid)
    {
        pControler.pAnimator.SetVitesseParameterValue(directionMove.magnitude);

        if (directionMove.magnitude > minValueToMove && pControler.pStatue.canMove)
        {
            /*Vector3 moveDirection = directionMove.normalized;
            moveDirection.y = rigid.velocity.y;
            Transform pTransform = rigid.transform;

            float newXdirec = moveDirection.x * pTransform.forward.normalized.x;
            float newYdirec = moveDirection.y * pTransform.forward.normalized.y;
            float newZdirec = moveDirection.z * pTransform.forward.normalized.z;

            moveDirection = new Vector3(newXdirec, newYdirec, newZdirec);

            rigid.velocity = moveDirection * speed;


            *//*Quaternion rotaCam = cam.rotation;
            rotaCam = new Quaternion(0, rotaCam.y, 0, 0);*//*

            pTransform.rotation = new Quaternion(0, cam.rotation.y, 0,pTransform.rotation.w);

            lastDirection = pTransform.position + moveDirection;

            axeRota.LookAt(lastDirection);*/


            float targetAngle = Mathf.Atan2(directionMove.x, directionMove.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(axeRota.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            axeRota.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirec = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDirec.y = rigid.velocity.y;
            rigid.velocity = moveDirec * speed;
        }
    }

}
