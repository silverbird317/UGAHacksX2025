using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("speed", Math.Abs(horizontalMove));

        /*
        if (Math.Abs(horizontalMove) > 0) {
            animator.SetBool("horizontalMove", true);
        } else {
            animator.SetBool("horizontalMove", false);
        } */
        
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("grounded", false);
        }
        
    }

    public void OnLanding() {
        animator.SetBool("grounded", true);
    }

    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
