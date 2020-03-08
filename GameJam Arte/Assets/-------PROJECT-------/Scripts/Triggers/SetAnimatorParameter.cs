using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorParameter : MonoBehaviour
{
    public Animator animator;

    public FloatParameter[] floatParameters = new FloatParameter[0];
    public IntParameter[] intParameters = new IntParameter[0];
    public BoolParameter[] boolParameters = new BoolParameter[0];
    public TriggerParameter[] triggersParameters = new TriggerParameter[0];

    public bool setParametersOnStart = true;
    public bool setParametersOnEnable = false;

    private void OnValidate()
    {
        foreach (GenericParameter parameter in floatParameters)
            parameter.UpdateNameHash();

        foreach (GenericParameter parameter in intParameters)
            parameter.UpdateNameHash();

        foreach (GenericParameter parameter in boolParameters)
            parameter.UpdateNameHash();

        foreach (GenericParameter parameter in triggersParameters)
            parameter.UpdateNameHash();
    }

    public void Reset()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Awake()
    {
        if (setParametersOnStart)
            SetParameters();
    }

    void OnEnable()
    {
        if (setParametersOnEnable)
            SetParameters();
    }

    public void SetParameters()
    {
        foreach (GenericParameter parameter in floatParameters)
            parameter.SetValue(animator);

        foreach (GenericParameter parameter in intParameters)
            parameter.SetValue(animator);

        foreach (GenericParameter parameter in boolParameters)
            parameter.SetValue(animator);

        foreach (GenericParameter parameter in triggersParameters)
            parameter.SetValue(animator);
    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    public abstract class GenericParameter
    {
        public string name;
        [HideInInspector]
        public int nameHash;
        public void UpdateNameHash()
        {
            nameHash = Animator.StringToHash(name);
        }
        public abstract void SetValue(Animator animator);
    }

    [System.Serializable]
    public class FloatParameter : GenericParameter
    {
        public float value;

        public override void SetValue(Animator animator)
        {
            animator.SetFloat(nameHash, value);
        }
    }

    [System.Serializable]
    public class IntParameter : GenericParameter
    {
        public int value;

        public override void SetValue(Animator animator)
        {
            animator.SetInteger(nameHash, value);
        }
    }

    [System.Serializable]
    public class BoolParameter : GenericParameter
    {
        public bool value;

        public override void SetValue(Animator animator)
        {
            animator.SetBool(nameHash, value);
        }
    }

    [System.Serializable]
    public class TriggerParameter : GenericParameter
    {
        public override void SetValue(Animator animator)
        {
            animator.SetTrigger(nameHash);
        }
    }


}
