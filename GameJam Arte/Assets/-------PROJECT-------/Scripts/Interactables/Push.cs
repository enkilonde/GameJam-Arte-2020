using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : Interactable
{
    private bool activated = false;

    private Vector2 previousPlayerPos;

    public override void Interact()
    {
        activated = !activated;
        previousPlayerPos = CharacterBehaviourManager.instance.transform.position;
    }

    protected override void CustomUpdate()
    {
        if (!activated)
            return;
        Vector2 playerPos = CharacterBehaviourManager.instance.transform.position;
        Vector2 playerDir = previousPlayerPos - playerPos;
        Vector2 wantedDir = (Vector2)transform.position - playerPos;

        if (Vector2.Dot(playerDir.normalized, wantedDir.normalized) < 0 && Input.GetAxis("Horizontal") != 0 && wantedDir.magnitude < radius)
            transform.position -= (Vector3)playerDir;

        previousPlayerPos = CharacterBehaviourManager.instance.transform.position;
    }

    public override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
    }
}
