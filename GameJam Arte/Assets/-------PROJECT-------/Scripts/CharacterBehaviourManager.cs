using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public List<CharacterBehaviour> allCharaBehaviour = new List<CharacterBehaviour>();
    public List<CharacterBehaviour> enabledCharaBehaviour = new List<CharacterBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
