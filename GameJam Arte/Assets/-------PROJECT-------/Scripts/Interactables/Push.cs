using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : Interactable
{
    private bool activated = false;

    private Vector2 previousPlayerPos;

    public override void Interact()
    {
        base.Interact();
        activated = !activated;
        previousPlayerPos = CharacterBehaviourManager.instance.transform.position;
    }

    protected override void CustomUpdate()
    {
        if (!activated)
            return;
        if (Input.GetAxis("Horizontal") == 0)
            return;

        Vector2 playerPos = CharacterBehaviourManager.instance.transform.position;
        Vector2 playerDir = previousPlayerPos - playerPos;
        Vector2 wantedDir = (Vector2)transform.position - playerPos;

        float horiz = Input.GetAxis("Horizontal");
        float dot = Vector3.Dot(Vector3.right, wantedDir.normalized);
        bool same = Mathf.Sign(dot) == Mathf.Sign(horiz);


        if (same && wantedDir.magnitude < radius)
        {
            if (playerDir.magnitude < 0.1f)
                transform.position += (Vector3)wantedDir * Time.deltaTime;
            else
            transform.position -= (Vector3)playerDir;
        }

        previousPlayerPos = CharacterBehaviourManager.instance.transform.position;

        if (wantedDir.magnitude > radius*2)
            activated = false;
    }

    public override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
    }
}
