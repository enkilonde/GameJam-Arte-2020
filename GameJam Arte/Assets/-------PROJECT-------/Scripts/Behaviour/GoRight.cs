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
            //CharacterBehaviourManager.instance.transform.position += Vector3.right * Time.deltaTime * speed;
            //CharacterBehaviourManager.instance.rigidbody2D.AddForce(Vector3.right * Time.deltaTime * speed);
            CharacterBehaviourManager.instance.rigidbody2D.velocity += Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        }
    }

    public override void CustomUpdate()
    {

    }
}
