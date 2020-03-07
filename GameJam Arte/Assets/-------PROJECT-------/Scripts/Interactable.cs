using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2;
    public Actions neededBehaviour;


    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && 
            Vector2.Distance(transform.position, CharacterBehaviourManager.instance.transform.position) <= radius && 
            CharacterBehaviourManager.instance.HasAction(neededBehaviour))
        {
            Interact();
        }
        CustomUpdate();
    }

    protected virtual void CustomUpdate() { }

    public virtual void Interact() { }

    public virtual void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
