﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BarSquare : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [HideInInspector] public List<BarSquare> followingSquares = new List<BarSquare>();

    public DragableObject contained = null;
    public bool locked = false;
    public bool hovered = false;

    public Image hoverIndicator;



    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MemoryBarManager.instance.dragedObject == null)
            return;

        if (followingSquares.Count < MemoryBarManager.instance.dragedObject.size-1)
            return;

        

        hovered = true;

        if(!locked)
        {
            hoverIndicator.enabled = true;

            for (int i = 0; i < Mathf.Min(followingSquares.Count, MemoryBarManager.instance.dragedObject.size - 1); i++)
            {
                followingSquares[i].hoverIndicator.enabled = true;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;



        hoverIndicator.enabled = false;
        if (MemoryBarManager.instance.dragedObject == null)
            return;
        for (int i = 0; i < Mathf.Min(followingSquares.Count, MemoryBarManager.instance.dragedObject.size - 1); i++)
        {
            followingSquares[i].hoverIndicator.enabled = false;
        }
    }




    void Start()
    {
        Unlock();
        MemoryBarManager.instance.OnDrop += OnDrop;
        bool seen = false;
        for (int i = 0; i < MemoryBarManager.instance.barSquares.Count; i++)
        {
            if (seen)
                followingSquares.Add(MemoryBarManager.instance.barSquares[i]);
            if (MemoryBarManager.instance.barSquares[i] == this)
                seen = true;
        }
    }

    void OnDestroy()
    {
        MemoryBarManager.instance.OnDrop -= OnDrop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnDrop()
    {
        if (locked || !hovered)
            return;

        OnAdd(MemoryBarManager.instance.dragedObject);

    }


    private void Lock()
    {
        locked = true;
        hoverIndicator.color = Color.grey;
        hoverIndicator.enabled = true;
    }

    private void Unlock()
    {
        locked = false;
        hoverIndicator.color = Color.yellow;
        hoverIndicator.enabled = false;
    }


    public void OnClick(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        if (pointerEventData.button == PointerEventData.InputButton.Right)
            OnRemove();
    }

    public void OnAdd(DragableObject objectToAdd)
    {
        OnRemove();

        GameObject draggedObj = Instantiate(objectToAdd.gameObject, transform.position, transform.rotation, transform.parent);
        contained = draggedObj.GetComponent<DragableObject>();
        contained.dragged = false;

        contained.transform.SetSiblingIndex(0);

        //Unlock
        for (int i = 0; i < followingSquares.Count; i++)
        {
            if (followingSquares[i].locked)
                followingSquares[i].Unlock();
            else
                break;
        }


        //Lock
        for (int i = 0; i < Mathf.Min(followingSquares.Count, contained.size - 1); i++)
        {
            followingSquares[i].Lock();
            if (followingSquares[i].contained != null)
            {
                Destroy(followingSquares[i].contained.gameObject);
            }
        }

        Image[] imagesDragged = contained.GetComponentsInChildren<Image>();
        for (int i = 0; i < imagesDragged.Length; i++)
        {
            imagesDragged[i].raycastTarget = false;
        }

        OnPointerExit(null);

        CharacterBehaviourManager.instance.enabledCharaBehaviour.Add(contained.characterBehaviour);
        contained.characterBehaviour.OnAdd();
    }

    void OnRemove()
    {
        if (contained != null)
        {
            contained.characterBehaviour.OnRemove();
            Destroy(contained.gameObject);
            CharacterBehaviourManager.instance.enabledCharaBehaviour.Remove(contained.characterBehaviour);

        }
    }

}