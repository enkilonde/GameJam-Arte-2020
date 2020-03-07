using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : CharacterBehaviour
{
    private bool jumping = false;
    public float jumpForce = 10;
    public float jumpForceDecrease = 5;

    private float jumForceDecreasing;

    public override void CustomFixedUpdate()
    {
        base.CustomFixedUpdate();

        if(Input.GetButtonDown("Jump") && CharacterBehaviourManager.instance.footCollider.onGround)
        {
            StartJump();
        }

        if (jumping && Input.GetButton("Jump"))
        {
            Jumping();
        }

        if (jumping && Input.GetButtonUp("Jump"))
        {
            jumpForceDecrease = 0;
        }

    }

    private void StartJump()
    {
        jumForceDecreasing = jumpForce;
    }

    private void Jumping()
    {
        CharacterBehaviourManager.instance.rigidbody2D.velocity += Vector2.up * jumForceDecreasing;
        jumForceDecreasing -= jumpForceDecrease * Time.fixedDeltaTime;
    }

    public override void CustomUpdate()
    {
    }
}
