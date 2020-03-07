using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : CharacterBehaviour
{
    public bool jumping = false;
    public float jumpForce = 10;
    public float jumpForceDecrease = 5;

    public float jumForceDecreasing;

    public override void CustomFixedUpdate()
    {
        base.CustomFixedUpdate();

        if(Input.GetButtonDown("Jump") && CharacterBehaviourManager.instance.footCollider.onGround)
        {
            StartJump();
        }

        if (jumForceDecreasing > 0)
        {
            Jumping();
        }

        if (jumping && Input.GetButtonUp("Jump"))
        {
            OnEndJump();
        }

    }

    private void StartJump()
    {
        Debug.Log("Jump!!!");
        jumForceDecreasing = jumpForce;
        jumping = true;
    }

    private void Jumping()
    {
        CharacterBehaviourManager.instance.rigidbody2D.velocity += Vector2.up * jumForceDecreasing;
        jumForceDecreasing -= jumpForceDecrease * Time.fixedDeltaTime;

        if(!Input.GetButton("Jump"))
        {
            jumForceDecreasing -= jumpForceDecrease * Time.fixedDeltaTime;
        }

        //if (CharacterBehaviourManager.instance.footCollider.onGround)
        //    OnEndJump();
    }

    private void OnEndJump()
    {
        //jumping = false;
    }

    public override void CustomUpdate()
    {
    }
}
