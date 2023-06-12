
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] VariableJoystick variableJoystick;
    [SerializeField] Animator animator;
    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        Vector3 rotation = Vector3.down * variableJoystick.Vertical;

        transform.DOMove(transform.position + direction, moveSpeed);

        if (variableJoystick.Vertical == 0 && variableJoystick.Horizontal == 0) 
        { 
            animator.SetBool("isRunning", false); 
            animator.SetBool("isWalking", false);
            return;
        }
        else if (Mathf.Abs(variableJoystick.Vertical) > 0.5f || Mathf.Abs(variableJoystick.Horizontal) > 0.5f)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", true);
        }

        transform.DORotate(new Vector3(0, Quaternion.LookRotation(direction).y*180,0), rotateSpeed); 
    }
}
