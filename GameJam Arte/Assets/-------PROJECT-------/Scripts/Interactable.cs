using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
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
    }

    public abstract void Interact();

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}
