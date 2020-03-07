using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBarManager : MonoBehaviour
{
    private static MemoryBarManager _instance;
    public static MemoryBarManager instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<MemoryBarManager>();
            return _instance;
        }
    }

    public List<BarSquare> barSquares;

    public DragableObject dragedObject;

    public Action OnDrop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnUpdateList()
    {
        
    }

    public void OnDropObject()
    {
        OnDrop?.Invoke();        
    }
}
