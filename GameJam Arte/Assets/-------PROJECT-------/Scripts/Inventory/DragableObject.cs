﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableObject : MonoBehaviour, IBeginDragHandler
{
    public bool dragged = false;
    RectTransform rectTransform;

    public float size = 1;
    public CharacterBehaviour characterBehaviour;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(2))
            return;
        GameObject draggedObj = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
        DragableObject dra = draggedObj.GetComponent<DragableObject>();
        dra.dragged = true;

        Image[] imagesDragged = dra.GetComponentsInChildren<Image>();
        for (int i = 0; i < imagesDragged.Length; i++)
        {
            imagesDragged[i].raycastTarget = false;
        }

        MemoryBarManager.instance.dragedObject = dra;
    }

    public void OnClick(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        if (pointerEventData.button == PointerEventData.InputButton.Middle)
            MemoryBarManager.instance.AddBehaviour(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dragged)
        {
            rectTransform.anchoredPosition = Input.mousePosition;

            if (Input.GetMouseButtonUp(0))
            {
                MemoryBarManager.instance.OnDrop();
                Destroy(gameObject);
            }
        }
    }
}