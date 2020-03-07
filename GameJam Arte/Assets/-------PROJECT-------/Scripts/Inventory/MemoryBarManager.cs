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

    public void OnDropObject()
    {
        OnDrop?.Invoke();
    }

    public void AddBehaviour(DragableObject dragableObject)
    {
        for (int i = 0; i < barSquares.Count - dragableObject.size + 1; i++)
        {
            if (barSquares[i].contained != null || barSquares[i].locked || barSquares[i].erased)
                continue;
            if(dragableObject.size == 1)
            {
                barSquares[i].OnAdd(dragableObject);
                return;
            }


            for (int j = 0; j < dragableObject.size - 1; j++)
            {
                if (barSquares[i].followingSquares[j].locked || barSquares[i].followingSquares[j].erased)
                    break;
                if(j == dragableObject.size - 2)
                {
                    barSquares[i].OnAdd(dragableObject);
                    return;
                }              
            }
        }
    }


    public void EraseRight()
    {
        for (int i = barSquares.Count-1; i >= 0; i--)
        {
            if (barSquares[i].erased)
                continue;
            barSquares[i].Erase();
            if (barSquares[i].locked)
            {
                for (int j = barSquares.Count - 2 - i; j >= 0; j++)
                {
                    if (barSquares[j].locked)
                        continue;
                    barSquares[j].OnRemove();
                }
            }
            else return;
        }
    }

}
