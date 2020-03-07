using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRight : CharacterBehaviour
{
    public float speed = 10;

    public override void CustomFixedUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            CharacterBehaviourManager.instance.rigidbody2D.velocity += Vector2.right * Input.GetAxis("Horizontal") * speed;

        }
    }

    public override void CustomUpdate()
    {

    }
}
