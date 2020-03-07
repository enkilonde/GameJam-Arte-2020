using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool dragged = false;
    RectTransform rectTransform;

    public float lenght = 1;
    public CharacterBehaviour characterBehaviour;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
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

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");

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
