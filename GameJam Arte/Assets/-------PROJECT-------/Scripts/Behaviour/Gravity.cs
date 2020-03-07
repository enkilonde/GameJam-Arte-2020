using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : CharacterBehaviour
{
    public Vector3 direction;

    public override void CustomUpdate()
    {
        CharacterBehaviourManager.instance.transform.position += direction * Time.deltaTime;
    }

}
