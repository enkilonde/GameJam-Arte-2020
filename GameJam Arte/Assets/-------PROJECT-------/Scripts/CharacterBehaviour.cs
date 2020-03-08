using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public Actions action;

    public virtual void CustomUpdate() { }
    public virtual void DisabledUpdate() { }
    public virtual void DisabledFixedUpdate() { }
    public virtual void CustomFixedUpdate() { }

    public virtual void OnAdd() { }
    public virtual void OnRemove() { }
    
}
