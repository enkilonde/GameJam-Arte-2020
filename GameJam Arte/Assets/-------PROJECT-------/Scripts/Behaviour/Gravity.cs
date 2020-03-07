using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : CharacterBehaviour
{
    public Vector2 direction;

    public override void CustomFixedUpdate()
    {
        base.CustomFixedUpdate();

        CharacterBehaviourManager.instance.rigidbody2D.velocity += direction;

    }

    public override void CustomUpdate()
    {
    }

}
