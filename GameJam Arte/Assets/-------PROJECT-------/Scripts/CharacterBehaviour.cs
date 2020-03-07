using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBehaviour : MonoBehaviour
{

    public abstract void CustomUpdate();
    public virtual void CustomFixedUpdate() { }

    public virtual void OnAdd() { }
    public virtual void OnRemove() { }
    
}
