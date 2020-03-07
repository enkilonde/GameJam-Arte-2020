using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollider : MonoBehaviour
{
    public bool onGround;


    private void FixedUpdate()
    {
        onGround = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        onGround = true;
    }

}
