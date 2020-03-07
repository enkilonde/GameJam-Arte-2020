using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : Interactable
{

    private bool activated = false;

    private Vector2 previousPlayerPos;

    public override void Interact()
    {
        activated = !activated;
    }

    private void Update()
    {
        if (!activated)
            return;
        Vector2 playerPos = CharacterBehaviourManager.instance.transform.position;
        Vector2 playerDir = previousPlayerPos - playerPos;
        Vector2 wantedDir = (Vector2)transform.position - playerPos;

        if (Vector2.Dot(playerDir.normalized, wantedDir.normalized) > 0)
            transform.position += (Vector3)playerDir;

        previousPlayerPos = CharacterBehaviourManager.instance.transform.position;
    }

}
