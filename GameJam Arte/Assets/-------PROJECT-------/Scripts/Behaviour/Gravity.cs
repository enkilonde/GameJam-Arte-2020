﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : CharacterBehaviour
{
    public Vector2 direction;

    public bool activated = false;

    public override void CustomFixedUpdate()
    {
        base.CustomFixedUpdate();

        CharacterBehaviourManager.instance.rigidbody2D.velocity -= direction;


    }

    public override void DisabledFixedUpdate()
    {
        base.DisabledUpdate();
        CharacterBehaviourManager.instance.rigidbody2D.velocity += direction;

    }

}
