using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Actions
{
    GoLeft,
    GoRight,
    Jump,
    Crouch,
    LookAround,
    Push,
    Pull,
    Talk,
    Hack,
    Hit,
    Gravity,
    Throw,
    ClimbUp,
    ClimbDown,
    OpenDoor,
    PushButton

}

public class CharacterBehaviourManager : MonoBehaviour
{
    private static CharacterBehaviourManager _instance;
    public static CharacterBehaviourManager instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<CharacterBehaviourManager>();
            return _instance;
        }
    }

    public Rigidbody2D rigidbody2D;
    public FootCollider footCollider;

    public CharacterBehaviour[] allCharaBehaviour;
    public List<CharacterBehaviour> enabledCharaBehaviour = new List<CharacterBehaviour>();

    public Animator animator;

    private void Awake()
    {
        allCharaBehaviour = GetComponentsInChildren<CharacterBehaviour>();
    }

    void Update()
    {
        for (int i = 0; i < enabledCharaBehaviour.Count; i++)
        {
            enabledCharaBehaviour[i].CustomUpdate();
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.zero;
        for (int i = 0; i < enabledCharaBehaviour.Count; i++)
        {
            enabledCharaBehaviour[i].CustomFixedUpdate();
        }
    }

    public bool HasAction(Actions action)
    {
        for (int i = 0; i < enabledCharaBehaviour.Count; i++)
        {
            if (enabledCharaBehaviour[i].action == action)
                return true;
        }
        return false;
    }

    public void AddBehaviour(Actions action)
    {
        for (int i = 0; i < allCharaBehaviour.Length; i++)
        {
            if(allCharaBehaviour[i].action == action)
            {
                enabledCharaBehaviour.Add(allCharaBehaviour[i]);
                allCharaBehaviour[i].OnAdd();
                return;
            }
        }
    }

    public void RemoveBehaviour(Actions action)
    {
        for (int i = 0; i < allCharaBehaviour.Length; i++)
        {
            if (allCharaBehaviour[i].action == action)
            {
                enabledCharaBehaviour.Remove(allCharaBehaviour[i]);
                allCharaBehaviour[i].OnRemove();
                return;
            }
        }
    }

}
